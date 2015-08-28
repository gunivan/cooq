using CooQ;
using CooQ.Column;
using CooQ.Function;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IUpdate
  {
    IUpdateSet Set<COLUMN>(COLUMN column, COLUMN value) where COLUMN : ColumnBase;

    IUpdateSet Set(SmallIntegerColumn column, short value);

    IUpdateSet Set(NSmallIntegerColumn column, short? value);

    IUpdateSet Set(IntegerColumn column, int value);

    IUpdateSet Set(NIntegerColumn column, int? value);

    IUpdateSet Set(BigIntegerColumn column, long value);

    IUpdateSet Set(NBigIntegerColumn column, long? value);

    IUpdateSet Set(StringColumn column, string value);

    IUpdateSet Set(DecimalColumn column, Decimal value);

    IUpdateSet Set(NDecimalColumn column, Decimal? value);

    IUpdateSet Set(DoubleColumn column, Double value);

    IUpdateSet Set(NDoubleColumn column, Double? value);

    IUpdateSet Set(DateTimeColumn column, DateTime value);

    IUpdateSet Set(DateTimeColumn column, CurrentDateTime value);

    IUpdateSet Set(NDateTimeColumn column, DateTime? value);

    IUpdateSet Set(NDateTimeColumn column, CurrentDateTime value);

    IUpdateSet Set(DateTime2Column column, DateTime value);

    IUpdateSet Set(DateTime2Column column, CurrentDateTime value);

    IUpdateSet Set(NDateTime2Column column, DateTime? value);

    IUpdateSet Set(NDateTime2Column column, CurrentDateTime value);

    IUpdateSet Set(DateTimeOffsetColumn column, DateTimeOffset value);

    IUpdateSet Set(DateTimeOffsetColumn column, CurrentDateTimeOffset value);

    IUpdateSet Set(NDateTimeOffsetColumn column, DateTimeOffset? value);

    IUpdateSet Set(NDateTimeOffsetColumn column, CurrentDateTimeOffset value);

    IUpdateSet Set(BoolColumn column, bool value);

    IUpdateSet Set(NBoolColumn column, bool? value);

    IUpdateSet Set(GuidColumn column, Guid value);

    IUpdateSet Set(NGuidColumn column, Guid? value);

    IUpdateSet Set(BinaryColumn column, byte[] value);

    IUpdateSet Set(NBinaryColumn column, byte[] value);

    IUpdateSet Set<TABLE>(GuidKeyColumn<TABLE> column, Guid value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(NGuidKeyColumn<TABLE> column, Guid? value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(SmallIntegerKeyColumn<TABLE> column, short value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(NSmallIntegerKeyColumn<TABLE> column, short? value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(IntegerKeyColumn<TABLE> column, int value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(NIntegerKeyColumn<TABLE> column, int? value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(BigIntegerKeyColumn<TABLE> column, long value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(NBigIntegerKeyColumn<TABLE> column, long? value) where TABLE : TableBase;

    IUpdateSet Set<TABLE>(StringKeyColumn<TABLE> column, string value) where TABLE : TableBase;
  }
}
