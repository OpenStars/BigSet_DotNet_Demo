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



public partial class TItemSet : TBase
{
  private List<TItem> _items;

  public List<TItem> Items
  {
    get
    {
      return _items;
    }
    set
    {
      __isset.items = true;
      this._items = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool items;
  }

  public TItemSet()
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
            if (field.Type == TType.List)
            {
              {
                TList _list4 = await iprot.ReadListBeginAsync(cancellationToken);
                Items = new List<TItem>(_list4.Count);
                for(int _i5 = 0; _i5 < _list4.Count; ++_i5)
                {
                  TItem _elem6;
                  _elem6 = new TItem();
                  await _elem6.ReadAsync(iprot, cancellationToken);
                  Items.Add(_elem6);
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
      var struc = new TStruct("TItemSet");
      await oprot.WriteStructBeginAsync(struc, cancellationToken);
      var field = new TField();
      if (Items != null && __isset.items)
      {
        field.Name = "items";
        field.Type = TType.List;
        field.ID = 1;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        {
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Items.Count), cancellationToken);
          foreach (TItem _iter7 in Items)
          {
            await _iter7.WriteAsync(oprot, cancellationToken);
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
    var other = that as TItemSet;
    if (other == null) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.items == other.__isset.items) && ((!__isset.items) || (TCollections.Equals(Items, other.Items))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if(__isset.items)
        hashcode = (hashcode * 397) + TCollections.GetHashCode(Items);
    }
    return hashcode;
  }

  public override string ToString()
  {
    var sb = new StringBuilder("TItemSet(");
    bool __first = true;
    if (Items != null && __isset.items)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Items: ");
      sb.Append(Items);
    }
    sb.Append(")");
    return sb.ToString();
  }
}

