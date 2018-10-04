# TestOwnedType

According to the Domain Driven Design the data in the Domain Entities need to be encapsulated. 

However with the current version of the Entity Framework Core 2.1, there are certain limitations that we need to be aware of:

As value object is immutable, its properties should be read only. 
However, read only properties will be ignored by EF core by default when creating EF entity model. 
They will be include in the model only when they are explicitly declared in configuration.
When configure read only property or field, parameterized constructor is needed. 
Currently, only scalar property, like string, double, Datetime, enum, can use parameterized constructor during model creation. 
Complex type cannot do in this way as it is not supported now. 
Allow related entities to be passed to constructor of aggregate root.  
Therefore, complex type property cannot be read only.
Parameterized constructor should be called by convention rather than empty constructor. 
However, it is supported only when query data, not supported when configure models. 
It leads to an embarrassing situation that we should have an empty private constructor in our entities, 
but must not have it in our value objects. Decide on which constructor to call by convention 
