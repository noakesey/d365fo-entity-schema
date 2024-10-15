# d365fo-entity-schema
This is a Visual Studio extension to generate an [entity relation schema](https://waywo.co.uk/2021/12/20/entity-relationship-diagrams/) for Microsoft Dynamics 365 Finance and Operations (D365FO) using Database Markup Language ([DBML](https://www.dbml.org/home/))

The extension allows you to modify the generated schema by
 - Adding / Removing individual tables
 - Adding all tables that have an inbound relation to the selected table
 - Adding all tables that have an outbound relation from the selected table
 - Adding all related tables for all tables in the list
 - Ignoring staging tables
 - Ignoring self references
 - Reducing the complexity of the schema by only including key fields

See this [blog](https://waywo.co.uk/2021/12/20/entity-relationship-diagrams/) for further details and example usage.

You can use a tool such as [dbdiagram.io](https://dbdiagram.io/d) to render the resulting DBML.

![image](https://github.com/noakesey/d365fo-entity-schema/assets/10977494/24226fc3-2a8b-4149-9cf7-135029fb8728)

The extension is accessible from the _Generate entity relation schema_ menu from  the Dynamics 365 Addins menu or from the table designer.

![image](https://github.com/noakesey/d365fo-entity-schema/assets/10977494/bef505a6-e4f8-4a60-8597-80865984058c)

## Installation

Download the Waywo.DbSchema.Addin.dll from [Releases](https://github.com/noakesey/d365fo-entity-schema/releases). Unblock the .dll once downloaded (right click and view properties in file explorer.)

In your _Documents\Visual Studio Dynamics 365_ folder there is a DynamicsDevConfig.xml XML file. like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<DynamicsDevConfig xmlns:i="http://www.w3.org/2001/XMLSchema-instance" 
                   xmlns="http://schemas.microsoft.com/dynamics/2012/03/development/configuration"> 	    
  <AddInPaths xmlns:d2p1="http://schemas.microsoft.com/2003/10/Serialization/Arrays"> 		 
      <d2p1:string>C:\D365CustomAddins</d2p1:string> 	
  </AddInPaths>   
</DynamicsDevConfig> 
```

Copy the Waywo.DBSchema.AddIn.dll to the AddInPath folder (create the folder or change the path as necessary) and then restart Visual Studio.

## Build
The referenced libraries will be in a folder similar to the following, depending on the platform version:
```
C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\XXXXXXXX.YYY\
```
It's important to build with the libraries included with Visual Studio rather than the libraries in the AOS folder.