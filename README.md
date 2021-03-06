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

You can use a tool such as [dbdiagram.io](https://dbdiagram.io/d) to render the resulting DBML.

You can open the extension from the _Generate entity relation schema_ menu from  the Dynamics 365 Addins menu or from the table designer.

### Installation

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
