using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  public class StreamParser
  {
    private Stream m_Stream;

    public StreamParser(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException("stream");
      }

      m_Stream = stream;
    }

    public long Position
    {
      get { return m_Stream.Position; }
    }

    public byte[] ReadBytes(int size)
    {
      if (size <= 0)
      {
        throw new ArgumentOutOfRangeException("size");
      }

      byte[] buffer = new byte[size];
      int read = m_Stream.Read(buffer, 0, size);
      if (read != size)
      {
        throw new ParseException("Expected {0} bytes, got only {1}.", size, read);
      }
      return buffer;
    }

    public string ReadNullTerminatedString(int codepage)
    {
      if (codepage == 1200)
      {
        return ReadUnicodeString();
      }
      var encoding = Encoding.GetEncoding(codepage);
      var buffer = new List<byte>(100);
      while(true)
      {
        int char0 = m_Stream.ReadByte();
        if (char0 == -1)
        {
          throw new ParseException("EOS reached.");
        }
        if (char0 == 0)
        {
          break;
        }
        buffer.Add((byte)char0);
      }

      return encoding.GetString(buffer.ToArray());
    }

    public string ReadUnicodeString()
    {
      var buffer = new List<byte>(100);
      while(true)
      {
        int char1 = m_Stream.ReadByte();
        if (char1 == -1)
        {
          throw new ParseException("EOS reached.");
        }
        int char2 = m_Stream.ReadByte();
        if (char2 == -1)
        {
          throw new ParseException("EOS reached.");
        }

        if (char1 == 0 && char2 == 0)
        {
          return Encoding.Unicode.GetString(buffer.ToArray());
        }

        buffer.Add((byte)char1);
        buffer.Add((byte)char2);
      }
    }

    public char[] ReadChars(int size, Encoding encoding)
    {
      if (size <= 0)
      {
        throw new ArgumentOutOfRangeException("size");
      }
      if (encoding == null)
      {
        throw new ArgumentNullException("encoding");
      }

      return encoding.GetChars(ReadBytes(size));
    }

    public IList<ushort> PadToFourBytes()
    {
      var result = new List<ushort>();
      while(Position % 4 != 0)
      {
        ushort word = ReadUInt16();
        if (word != 0)
        {
          throw new ParseException("Invalid padding.");
        }
        result.Add(0);
      }
      return result;
    }

    public short ReadInt16()
    {
      byte[] buffer = ReadBytes(2);
      return (short)((buffer[1] * 256) + buffer[0]);
    }

    public ushort ReadUInt16()
    {
      byte[] buffer = ReadBytes(2);
      return (ushort)((buffer[1] * 256) + buffer[0]);
    }

    public byte ReadByte()
    {
      int result = m_Stream.ReadByte();
      if (result == -1)
      {
        throw new ParseException("Already at EOS.");
      }
      return (byte)result;
    }

    public void Seek(long offset, SeekOrigin origin)
    {
      m_Stream.Seek(offset, origin);
    }

    public short[] ReadInt16s(int size)
    {
      if (size <= 0)
      {
        throw new ArgumentOutOfRangeException("size");
      }
      short[] result = new short[size];
      for(var i =0; i < size; i++)
      {
        result[i] = ReadInt16();
      }
      return result;
    }


    public uint ReadUInt32()
    {
      byte[] buffer = ReadBytes(4);
      return (uint)(256 * 256 * 256 * buffer[3]) +
        (uint)(256 * 256 * buffer[2]) +
        (uint)(256 * buffer[1]) +
        buffer[0];
    }

    public int ReadInt32()
    {
      byte[] buffer = ReadBytes(4);
      return (256 * 256 * 256 * buffer[3]) +
        (256 * 256 * buffer[2]) +
        (256 * buffer[1]) +
        buffer[0];
    }

    public long ReadInt64()
    {
      byte[] buffer = ReadBytes(8);
      return
        (256L * 256 * 256 * 256 * 256 * 256 * 256 * buffer[7]) +
        (256L * 256 * 256 * 256 * 256 * 256 * buffer[6]) +
        (256L * 256 * 256 * 256 * 256 * buffer[5]) +
        (256L * 256 * 256 * 256 * buffer[4]) +
        (256 * 256 * 256 * buffer[3]) +
        (256 * 256 * buffer[2]) +
        (256 * buffer[1]) +
        buffer[0];
    }
  }
}
