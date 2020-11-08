## LINQ:

Language Integrated Query language.

- Source
- Query
- Execution.

#### #1#Projection:

**Query Syntax**

- from p in Source Select p
- from p in Source Select new{}
- from p in Source Select((value,index)=> new{value,index})Select new{}
- from p in source q in p.EnumerableSource Select new{}
  **Query Method**
- source.ToList();
- source.Select(p=> new{}).ToList();
- source.Select((p,i)=> new{}).ToList();
- source.SelectMany(p=>p.EnumerableSource,(v,q) new{}).ToList();

#### #2#Filtering

**Query Syntax**

**Query Method**

#### #3#Set Operator

**Query Syntax**

**Query Method**

#### #4#

**Query Syntax**

**Query Method**

#### #5#Order Operators

**Query Syntax**

**Query Method**

#### #6#Aggregate Function

**Query Syntax**

**Query Method**

#### #7#Quantifier Operators

**Query Syntax**

**Query Method**

#### #8#GroupBy Operators

**Query Syntax**

**Query Method**
