using CooQ;
using CooQ.Column;
using CooQ.Function;
using System;

namespace CooQ.Interfaces
{
  public interface IInsertSet : IInsertUseParams, IInsertTimeout, IReturning, IInsertExecute
  {
    IInsertSet Set(SmallIntegerColumn column, short value);

    IInsertSet Set(NSmallIntegerColumn column, short? value);

    IInsertSet Set(IntegerColumn column, int value);

    IInsertSet Set(NIntegerColumn column, int? value);

    IInsertSet Set(BigIntegerColumn column, long value);

    IInsertSet Set(NBigIntegerColumn column, long? value);

    IInsertSet Set(StringColumn column, string value);

    IInsertSet Set(DecimalColumn column, Decimal value);

    IInsertSet Set(NDecimalColumn column, Decimal? value);

    IInsertSet Set(DoubleColumn column, Double value);

    IInsertSet Set(NDoubleColumn column, Double? value);   

    IInsertSet Set(DateTimeColumn column, DateTime value);

    IInsertSet Set(DateTimeColumn column, CurrentDateTime value);

    IInsertSet Set(NDateTimeColumn column, DateTime? value);

    IInsertSet Set(NDateTimeColumn column, CurrentDateTime value);

    IInsertSet Set(DateTime2Column column, DateTime value);

    IInsertSet Set(DateTime2Column column, CurrentDateTime value);

    IInsertSet Set(NDateTime2Column column, DateTime? value);

    IInsertSet Set(NDateTime2Column column, CurrentDateTime value);

    IInsertSet Set(DateTimeOffsetColumn column, DateTimeOffset value);

    IInsertSet Set(DateTimeOffsetColumn column, CurrentDateTimeOffset value);

    IInsertSet Set(NDateTimeOffsetColumn column, DateTimeOffset? value);

    IInsertSet Set(NDateTimeOffsetColumn column, CurrentDateTimeOffset value);

    IInsertSet Set(BoolColumn column, bool value);

    IInsertSet Set(NBoolColumn column, bool? value);

    IInsertSet Set(GuidColumn column, Guid value);

    IInsertSet Set(NGuidColumn column, Guid? value);

    IInsertSet Set(BinaryColumn column, byte[] value);

    IInsertSet Set(NBinaryColumn column, byte[] value);

    IInsertSet Set<ENUM>(EnumColumn<ENUM> column, ENUM value);

    IInsertSet Set(ColumnBase column, CustomSql value);

    IInsertSet Set<TABLE>(GuidKeyColumn<TABLE> column, Guid value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(NGuidKeyColumn<TABLE> column, Guid? value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(SmallIntegerKeyColumn<TABLE> column, short value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(NSmallIntegerKeyColumn<TABLE> column, short? value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(IntegerKeyColumn<TABLE> column, int value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(NIntegerKeyColumn<TABLE> column, int? value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(BigIntegerKeyColumn<TABLE> column, long value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(NBigIntegerKeyColumn<TABLE> column, long? value) where TABLE : TableBase;

    IInsertSet Set<TABLE>(StringKeyColumn<TABLE> column, string value) where TABLE : TableBase;
  }
}
