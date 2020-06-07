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



public partial class SplitJob : TBase
{
  private TNeedSplitInfo _splitInfo;

  public long RootID { get; set; }

  public TNeedSplitInfo SplitInfo
  {
    get
    {
      return _splitInfo;
    }
    set
    {
      __isset.splitInfo = true;
      this._splitInfo = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool splitInfo;
  }

  public SplitJob()
  {
  }

  public SplitJob(long rootID) : this()
  {
    this.RootID = rootID;
  }

  public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_rootID = false;
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
            if (field.Type == TType.I64)
            {
              RootID = await iprot.ReadI64Async(cancellationToken);
              isset_rootID = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.Struct)
            {
              SplitInfo = new TNeedSplitInfo();
              await SplitInfo.ReadAsync(iprot, cancellationToken);
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
      if (!isset_rootID)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
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
      var struc = new TStruct("SplitJob");
      await oprot.WriteStructBeginAsync(struc, cancellationToken);
      var field = new TField();
      field.Name = "rootID";
      field.Type = TType.I64;
      field.ID = 1;
      await oprot.WriteFieldBeginAsync(field, cancellationToken);
      await oprot.WriteI64Async(RootID, cancellationToken);
      await oprot.WriteFieldEndAsync(cancellationToken);
      if (SplitInfo != null && __isset.splitInfo)
      {
        field.Name = "splitInfo";
        field.Type = TType.Struct;
        field.ID = 2;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await SplitInfo.WriteAsync(oprot, cancellationToken);
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
    var other = that as SplitJob;
    if (other == null) return false;
    if (ReferenceEquals(this, other)) return true;
    return System.Object.Equals(RootID, other.RootID)
      && ((__isset.splitInfo == other.__isset.splitInfo) && ((!__isset.splitInfo) || (System.Object.Equals(SplitInfo, other.SplitInfo))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      hashcode = (hashcode * 397) + RootID.GetHashCode();
      if(__isset.splitInfo)
        hashcode = (hashcode * 397) + SplitInfo.GetHashCode();
    }
    return hashcode;
  }

  public override string ToString()
  {
    var sb = new StringBuilder("SplitJob(");
    sb.Append(", RootID: ");
    sb.Append(RootID);
    if (SplitInfo != null && __isset.splitInfo)
    {
      sb.Append(", SplitInfo: ");
      sb.Append(SplitInfo== null ? "<null>" : SplitInfo.ToString());
    }
    sb.Append(")");
    return sb.ToString();
  }
}

