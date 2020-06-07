/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;



public partial class TMultiPutItemResult : TBase
{
  private TErrorCode _error;
  private List<byte[]> _added;
  private List<TItem> _replaced;

  /// <summary>
  /// 
  /// <seealso cref="TErrorCode"/>
  /// </summary>
  public TErrorCode Error
  {
    get
    {
      return _error;
    }
    set
    {
      __isset.error = true;
      this._error = value;
    }
  }

  public List<byte[]> Added
  {
    get
    {
      return _added;
    }
    set
    {
      __isset.added = true;
      this._added = value;
    }
  }

  public List<TItem> Replaced
  {
    get
    {
      return _replaced;
    }
    set
    {
      __isset.replaced = true;
      this._replaced = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool error;
    public bool added;
    public bool replaced;
  }

  public TMultiPutItemResult()
  {
  }

  public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      await iprot.ReadStructBeginAsync(cancellationToken);
      while (true)
      {
        field = await iprot.ReadFieldBeginAsync(cancellationToken);
        if (field.Type == TType.Stop)
        {
          break;
        }

        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32)
            {
              Error = (TErrorCode)await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.List)
            {
              {
                TList _list20 = await iprot.ReadListBeginAsync(cancellationToken);
                Added = new List<byte[]>(_list20.Count);
                for(int _i21 = 0; _i21 < _list20.Count; ++_i21)
                {
                  byte[] _elem22;
                  _elem22 = await iprot.ReadBinaryAsync(cancellationToken);
                  Added.Add(_elem22);
                }
                await iprot.ReadListEndAsync(cancellationToken);
              }
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.List)
            {
              {
                TList _list23 = await iprot.ReadListBeginAsync(cancellationToken);
                Replaced = new List<TItem>(_list23.Count);
                for(int _i24 = 0; _i24 < _list23.Count; ++_i24)
                {
                  TItem _elem25;
                  _elem25 = new TItem();
                  await _elem25.ReadAsync(iprot, cancellationToken);
                  Replaced.Add(_elem25);
                }
                await iprot.ReadListEndAsync(cancellationToken);
              }
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          default: 
            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            break;
        }

        await iprot.ReadFieldEndAsync(cancellationToken);
      }

      await iprot.ReadStructEndAsync(cancellationToken);
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
  {
    oprot.IncrementRecursionDepth();
    try
    {
      var struc = new TStruct("TMultiPutItemResult");
      await oprot.WriteStructBeginAsync(struc, cancellationToken);
      var field = new TField();
      if (__isset.error)
      {
        field.Name = "error";
        field.Type = TType.I32;
        field.ID = 1;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async((int)Error, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (Added != null && __isset.added)
      {
        field.Name = "added";
        field.Type = TType.List;
        field.ID = 2;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        {
          await oprot.WriteListBeginAsync(new TList(TType.String, Added.Count), cancellationToken);
          foreach (byte[] _iter26 in Added)
          {
            await oprot.WriteBinaryAsync(_iter26, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
        }
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (Replaced != null && __isset.replaced)
      {
        field.Name = "replaced";
        field.Type = TType.List;
        field.ID = 3;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        {
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Replaced.Count), cancellationToken);
          foreach (TItem _iter27 in Replaced)
          {
            await _iter27.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
        }
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      await oprot.WriteFieldStopAsync(cancellationToken);
      await oprot.WriteStructEndAsync(cancellationToken);
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override bool Equals(object that)
  {
    var other = that as TMultiPutItemResult;
    if (other == null) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.error == other.__isset.error) && ((!__isset.error) || (System.Object.Equals(Error, other.Error))))
      && ((__isset.added == other.__isset.added) && ((!__isset.added) || (TCollections.Equals(Added, other.Added))))
      && ((__isset.replaced == other.__isset.replaced) && ((!__isset.replaced) || (TCollections.Equals(Replaced, other.Replaced))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if(__isset.error)
        hashcode = (hashcode * 397) + Error.GetHashCode();
      if(__isset.added)
        hashcode = (hashcode * 397) + TCollections.GetHashCode(Added);
      if(__isset.replaced)
        hashcode = (hashcode * 397) + TCollections.GetHashCode(Replaced);
    }
    return hashcode;
  }

  public override string ToString()
  {
    var sb = new StringBuilder("TMultiPutItemResult(");
    bool __first = true;
    if (__isset.error)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Error: ");
      sb.Append(Error);
    }
    if (Added != null && __isset.added)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Added: ");
      sb.Append(Added);
    }
    if (Replaced != null && __isset.replaced)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Replaced: ");
      sb.Append(Replaced);
    }
    sb.Append(")");
    return sb.ToString();
  }
}

