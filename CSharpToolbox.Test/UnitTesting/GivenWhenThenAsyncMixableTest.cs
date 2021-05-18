using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using CSharpToolbox.UnitTesting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.UnitTesting
{
    public class AFileStream
    {
        public void Given(StreamTestBase tbase)
        {
            tbase.Stream = new FileStream("", FileMode.Create);
        }
    }

    public class ANetworkStream
    {
        public void Given(StreamTestBase tbase)
        {
            tbase.Stream = new NetworkStream(new Socket(SocketType.Stream, ProtocolType.Tcp));
        }
    }

    public class NumbersFromOneToTen
    {
        public void Given(StreamTestBase tbase)
        {
            tbase.Payload = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }
    }

    public class BytesAreRead
    {
        public void When(StreamTestBase tbase)
        {
            tbase.Bytes = new byte[10];
            tbase.Stream.Read(tbase.Bytes, 0, 10);
        }
    }

    public class BytesAreWritten
    {
        public void When(StreamTestBase tbase)
        {
            tbase.Stream.Write(tbase.Payload, 0, tbase.Payload.Length);
        }
    }

    public class TheResultIsEmpty
    {
        public void Then(StreamTestBase tbase)
        {
            tbase.Bytes.Should().BeEmpty();
        }
    }
    public class TheResultIsNotEmpty
    {
        public void Then(StreamTestBase tbase)
        {
            tbase.Bytes.Should().NotBeEmpty();
        }
    }

    public abstract class StreamTestBase : GivenWhenThen
    {
        public Stream Stream;
        public byte[] Payload;
        public byte[] Bytes;
    }

    [TestClass]
    public class StreamTests : StreamTestBase
    {
        [TestMethod]
        public void FileReadTest()
        {
            //Given<AFileStream>();
            //When<BytesAreRead>();
            //Then<TheResultIsNotEmpty>();
        }

        [TestMethod]
        public void FileWriteTest()
        {
            //Given<AFileStream, NumbersFromOneToTen>();
            //When<BytesAreWritten>();
            //Then<TheResultIsEmpty>();
        }

        [TestMethod]
        public void NetworkReadTest()
        {
            //Given<ANetworkStream>();
            //When<BytesAreRead>();
            //Then<TheResultIsNotEmpty>();
        }

        [TestMethod]
        public void NetworkWriteTest()
        {
            //Given<ANetworkStream, NumbersFromOneToTen>();
            //When<BytesAreWritten>();
            //Then<TheResultIsEmpty>();
        }
    }
}