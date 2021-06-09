 * Project Name : SITA_Assignment.
 * Technology Used: ASP.Net MVC, JQuery
 * Design Pattern Used : Factory Design Pattern
 * Dependency Injection Used: Yes ( Ninject 3rd party library used).
 * Solid Principle Implemented: Yes
 * Visual Studio Version Needed : VS 2013 Or Higher
 
<b> Demonstration:</b>
 
 * Open the application in visual studio 2013 or Higher
 * Run the application.
 * Upload the xml file by clicking on the file uploader button. In this application, I have restricted files other than .xml format. so when user click on file uploader, so only xml file will be visible for upload file.
 * After file selection, click on upload button. It will call JQuery ajax method and from here ajax call will done and request came into "UploadXmlFile" action method of home controller.
 * In "UploadXmlFile" action method, file will save into local folder "UploadedFiles".
 * Once file save in local folder , than code will call "GetParcelData" method of "ParcelBAL" class and in this method xml file data deserialized into c# model class.
 * Once data DeSerialized into c# model class, control will come into "UploadXmlFile" method of home controller and that method will call "GeneratePlannedData" method of "ParcelBAL" Class.
 * In "GeneratePlannedData" business logic will execute based on below scenerios.
	1) Parcels with a weight up to 1 kg are handled by the "Mail" departement.
	2) Parcels with a weight up to 10 kg are handled by the "Regular" department.
	3) Parcels with a weight over 10 kg are handled by the "Heavy" department.
	4) Parcels with a value of over € 1000,- need to be signed off by the "Insurance" department, before being processed by Mail, Regular or Heavy department.
 * Once Planned Data will generate based on above mentioned business cases, controller will called "_plan" partial view, where I had written html table code for showing parcel data on UI.
 * Once response generated from partial view render, it will call success method of ajax function and append partial view html into div and show html table on UI.
 * If any error occured in above process, code will execute catch block of "UploadXmlFile" and html alert will shown on UI saying error occured.
 * If user directly click on Upload button without selecting any file in file uploader, one msg saying that "No file selected. Please choose xml file from file uploader" is displayed on UI
 
 <b>Dependency Injection Implementation:</b>
 
 * Install NInject.mvc package from nuget package manager.
 * It will create NinjectWebCommon.cs file under app_Start folder.
 * Create NinjectResolver.cs class under app_start folder and implement IDependencyResolver interface on it.
 * Implement all the methods of IDependencyResolver in NinjectResolver.cs class and add class and interface binding in AddBindings method as mentioned below:
	this._kernel.Bind<IParcel>().To<ParcelBAL>();
 * Register NinjectResolver in application_Start method of global.asax.cs class.
 * Inject ParcelBAL class dependency on home controller constructor level by creating instance of interface IParcel.
 * Calling methods of ParcelBAL by using instance of interface IParcel.
 
 <b>Factory Design Pattern Implementation:</b>
 
 * Create DepartmentProduct Abstract class and create 3 abstract property on it.
 * Create 3 Concrete Product class who inherit abstract product class DepartmentProduct . Name of these 3 concrete Product class mentioned below:
	1) MailDepartment ( ~/BusinessLayer/Factory/MailDepartment)
	2)RegularDepartment( ~/BusinessLayer/Factory/RegularDepartment)
	3)HeavyDepartment( ~/BusinessLayer/Factory/HeavyDepartment)
 * Create Creator i.e DepartmentFactory (Abstract class) and defined GetDepartment Abstract Method.
 * Create 3 Concrete Creator class which Inherit creator abstract class i.e DepartmentFactory.cs .Name of these 3 concrete Creator class mentioned below:
	1) MailFactory
	2)RegularFactory
	3)HeavyFactory
	
 * At the end create object of Concrete Creator  class object at run time based on parcel weight in "GeneratePlannedData" method of parcelBAL.cs class.
 
 <b>Adding or removing a department:</b>
 
 * For Adding another department, we just need to create concrete product class for new department and inherit it into abstract product class i.e. DepartmentProduct.
 Then we need to create Concrete creator class for new department and inherit it into creator abstract class i.e. DepartmentFactory.cs
 At last we need to add if else condition for new business rule(if any) in "GeneratePlannedData" method of ParcelBAL.cs class
 
 * For removing department, we just need to remove if else condition of removed business logic.
 
 
 Thank you 
 
