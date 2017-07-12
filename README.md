## Introduction

- The main idea started from: [jOOQ](http://www.jooq.org), [typedquery](https://github.com/EndsOfTheEarth/Typed-Query)
- Useful library to make `typed-safe` query to database, currently support `PostgreSQL` and `MSSQL`.
- UI tool to generate mapped class from database.
- Use `CooQ` with existing ORM project, the only thing need to do is generate classes and make query with syntax as below.

## Background

- Already work with ADO.NET

## Generate Database Objects Class

- Currently supports 2 database types - `MSSQL` and `PostgreSQL`. I use velocity to generate class by template. - You can extend as you want.

- To generate template, you should open file `CooQGenerate.exe` then fill specific required information to connect to your database, then click Generate button.

- Init  `CooQ` with Connection String

- You must init some information for `CooQ` once.

```c#
//for PostgreSQl
CooQ.Query.Init(new CooQ.ConnectionSetting()
  {
    Server = "localhost",
    Database = "database_name",
    Username = "postgres",
    Password = "root",
    Port = 5432,
    Type = CooQ.Types.DatabaseType.POSTGRESQL
});
```

```c#
//for MSSQL
CooQ.Query.Init(new CooQ.ConnectionSetting()
  {
    Server = @".\SQLEXPRESS",
    Database = "database_name",
    Type = CooQ.Types.DatabaseType.MSSQL
});
```

- Make Query.
Note that your database naming convention should be lowercase with _, for example your table name is TableTest then it should be table_test in your database.

Suppose you create a table in your database named table_test and your generated class is:

```c#
//we have 2 mapped class after generated:
Table.TableTest.cs
Record.TableTestRecord.cs
Supposed that table_test have 2 columns named column_a, column_b.
```

```c#
//We have two mapped columns after generated:
TableTest.TABLETEST.COLUMNA
TableTest.TABLETEST.COLUMNB
Then, you make a first query as below:
```

- Select Query
```c#
IQueryable<Record> res = CooQ.Query.Select(TableTest.TABLETEST)
       .From(TableTest.TABLETEST)
       .Execute()
       .GetRows();

foreach (TableTestRecord record in res)
 {
   //your code here...
   Debug.Print("Column A is:" + record.ColumnA);
 }
 ```

 - Insert Query
```c#
Query.Insert(TableTest.TABLETEST)
      .Set(TableTest.TABLETEST.COLUMNA, "value 1")
      .Set(TableTest.TABLETEST.COLUMNB, "value 2");
```

- Update Query
```c#
Query.Update(TableTest.TABLETEST)
      .Set(TableTest.TABLETEST.COLUMNA, "value 1")
      .Set(TableTest.TABLETEST.COLUMNB, "value 2");
```

- Delete Query
```c#
Query.Delete(TableTest.TABLETEST)
        .Where(TableTest.TABLETEST.COLUMNA = "value 1");
```

## License
This article, along with any associated source code and files, is licensed under [The MIT License](http://www.opensource.org/licenses/mit-license.php)

