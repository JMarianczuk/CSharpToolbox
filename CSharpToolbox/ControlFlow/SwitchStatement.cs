using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharpToolbox.Collections;

namespace CSharpToolbox.ControlFlow
{
    public abstract class SwitchStatementBase<TMatch, TResult> : IEnumerable<SwitchStatementBase<TMatch, TResult>.SwitchSection>
        where TMatch : IEquatable<TMatch>
    {
        protected abstract IEnumerable<SwitchSection> SectionsInternal { get; }
        protected abstract DefaultSection DefaultInternal { get; }

        public IEnumerator<SwitchSection> GetEnumerator()
        {
            return SectionsInternal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public SwitchResult Execute(TMatch matchExpression)
        {
            SwitchSection matched;
            if (matchExpression == null)
            {
                matched = SectionsInternal.FirstOrDefault(s => s.Value == null);
            }
            else
            {
                matched = SectionsInternal.FirstOrDefault(s => matchExpression.Equals(s.Value));
            }
            if (matched is null)
            {
                if (DefaultInternal != null)
                {
                    DefaultInternal.Action?.Invoke();
                    return new SwitchResult()
                    {
                        Matched = true,
                        Result = DefaultInternal.Result,
                    };
                }
                else
                {
                    return new SwitchResult()
                    {
                        Matched = false,
                    };
                }
            }
            else
            {
                matched.Action?.Invoke();
                return new SwitchResult()
                {
                    Matched = true,
                    Result = matched.Result,
                };
            }
        }

        public class DefaultSection
        {
            public Action Action { get; set; }
            public TResult Result { get; set; }
        }

        public class SwitchResult
        {
            public bool Matched { get; internal set; }
            public TResult Result { get; internal set; }

            public SwitchResult()
            {

            }
        }

        public class SwitchSection
        {
            public TMatch Value { get; }
            public Action Action { get; }
            public TResult Result { get; }

            public SwitchSection(TMatch value, Action action, TResult result)
            {
                Value = value;
                Action = action;
                Result = result;
            }
            public static SwitchSection Create(TMatch value, Action action, TResult result)
            {
                return new SwitchSection(value, action, result);
            }
        }
    }
    public class SwitchStatement<TMatch, TResult> : SwitchStatementBase<TMatch, TResult>, 
        ICollectionInitializable<TMatch, Action, TResult>
            where TMatch : IEquatable<TMatch>
    {
        private readonly InitializableCollection<SwitchSection, TMatch, Action, TResult> _cases = 
            new InitializableCollection<SwitchSection, TMatch, Action, TResult>(SwitchSection.Create);
        public ICollectionInitializable<TMatch, Action, TResult> Cases => _cases;
        protected override IEnumerable<SwitchSection> SectionsInternal => _cases;

        public DefaultSection Default { get; set; }
        protected override DefaultSection DefaultInternal => Default;

        public void Add(TMatch value, Action action, TResult result)
        {
            Cases.Add(value, action, result);
        }
    }

    public class SwitchStatement<TMatch> : SwitchStatementBase<TMatch, bool>,
        ICollectionInitializable<TMatch, Action>
            where TMatch : IEquatable<TMatch>
    {
        public const bool DefaultReturnValue = true;

        private readonly InitializableCollection<SwitchSection, TMatch, Action> _cases = 
            new InitializableCollection<SwitchSection, TMatch, Action>((value, action) =>
                new SwitchSection(value, action, DefaultReturnValue));
        public ICollectionInitializable<TMatch, Action> Cases => _cases;
        protected override IEnumerable<SwitchSection> SectionsInternal => _cases;

        public DefaultSection Default { get; set; }

        protected override SwitchStatementBase<TMatch, bool>.DefaultSection DefaultInternal
        {
            get
            {
                if (Default == null)
                {
                    return null;
                }
                else
                {
                    return new SwitchStatementBase<TMatch, bool>.DefaultSection()
                    {
                        Action = Default.Action, 
                        Result = DefaultReturnValue
                    };
                }
            }
        } 
        public void Add(TMatch value, Action action)
        {
            Cases.Add(value, action);
        }

        public new class DefaultSection
        {
            public Action Action { get; set; }
        }
    }

    public class MapStatement<TMatch, TResult> : SwitchStatementBase<TMatch, TResult>,
        ICollectionInitializable<TMatch, TResult>
            where TMatch : IEquatable<TMatch>
    {
        private const Action DefaultAction = null;

        private readonly InitializableCollection<SwitchSection, TMatch, TResult> _cases =
            new InitializableCollection<SwitchSection, TMatch, TResult>((value, result) =>
                new SwitchSection(value, DefaultAction, result));
        public ICollectionInitializable<TMatch, TResult> Cases => _cases;
            
        protected override IEnumerable<SwitchSection> SectionsInternal => _cases;

        public DefaultSection Default { get; set; }

        protected override SwitchStatementBase<TMatch, TResult>.DefaultSection DefaultInternal
        {
            get
            {
                if (Default == null)
                {
                    return null;
                }
                else
                {
                    return new SwitchStatementBase<TMatch, TResult>.DefaultSection()
                    {
                        Action = DefaultAction, 
                        Result = Default.Result
                    };
                }
            }
        }
        public void Add(TMatch value, TResult result)
        {
            Cases.Add(value, result);
        }

        public new class DefaultSection
        {
            public TResult Result { get; set; }
        }
    }
}