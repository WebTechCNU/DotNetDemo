// See https://aka.ms/new-console-template for more information
using DotNetDemo._02_OOP;
using DotNetDemo._03_delegates_events;
using DotNetDemo._04_interfaces_generics;

Console.WriteLine("Hello, World!");

//var objService = new BaseService();
//var objService2 = new BaseService();
//Console.WriteLine( objService2.ConnectionString);

////IDeletionService service = new DerivedService();

/////

////service.DeleteProduct(1);


//AbstractService service = new AddService();
//service.DoStuffRedefine(2, 3);
//service.GetResult();
//service.SomeMethod();

//service = new MultiplyService();
//service.DoStuffRedefine(2, 3);
//service.GetResult();

//service.SomeMethod();

//var homeTask = new HomeTask();
//homeTask.Main();

var service = new InterfacesDemo();
service.Main();