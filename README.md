# URL http://localhost:5171/swagger/index.html

# Example appsettings.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=yourpassowrd;Database=task-management;"
  }
}
```



# REST API

The REST API to the example app is described below.

## User

### Request
`POST /api/user/create-user-with-role`

Creates user with role assigned, currently role can be only 'admin' which has all the permissions (Task-Create, Task-Update, Task-Delete) or 'user'.

```
{
  "Username": "testusername",
  "Email": "testusername@example.com",
  "Password": "SomeTestUserPass198^&)",
  "RoleName": "admin"
}
```

### Response
Message field returns id of the user that is created.
  ```
  {
    "StatusCode": 201,
    "Status": "created",
    "Message": "7b0c766e-b38a-4617-aa89-c26aaa0f6427"
  }
  ```
  
  

### Request 
`POST /api/user/give-permission`
Gives permission to user (Task-Create, Task-Update, Task-Delete).

To accomplish that we need to provide:

* AdminId: as only admins can give other user permission.

* UserId: to know which user should have provided permission.

* PermissionName: Task-Create, Task-Update, Task-Delete

```
{
  "AdminId": "7b0c766e-b38a-4617-aa89-c26aaa0f6427",
  "UserId": "772c235b-5205-42ae-be60-47541d463dd8",
  "PermissionName": "Task-Create"
}
```

### Response
Message field returns id of the user that is created.
  ```
  {
    StatusCode = 201,
    Status = "created", 
    Message = "Permission has been successfully given"
  }
  ```



## Task

### Request
`POST /api/task/create`

Creates task by checking if task creator has right permission.

```
{
  "Title": "string",
  "ShortDescription": "string",
  "Description": "string",
  "AttachedFiles": "string",
  "AssignedTo": "string",
  "UserId": "772c235b-5205-42ae-be60-47541d463dd8"
}
```

### Response
Message field returns id of the user that is created.
  ```
  {
     StatusCode = 201,        
     Status = "created", 
     Message = "task created successfully"
  }
  ```
  
### Request
`PUT /api/task/update`

Updates task by checking if task creator has right permission.

```
{
  "Title": "string",
  "ShortDescription": "string",
  "Description": "string",
  "AttachedFiles": "string",
  "AssignedTo": "string",
  "UserId": "772c235b-5205-42ae-be60-47541d463dd8"
}
```

### Response
Message field returns id of the user that is created.
  ```
  {
     StatusCode = 200,        
     Status = "ok", 
     Message = "task updated successfully"
  }
```


### Request
`DELETE /api/task/delete`
Deletes task.
To accomplish that we need to provide user id to check if user has right permission and task id to know which task to remove.

```
* task-id
* user-id
```

### Response
Message field returns id of the user that is created.
  ```
  {
      StatusCode = 204, 
      Status = "no content", 
      Message = "task deleted successfully"
  }
 ```
 
 
 ### Request
`GET /api/task`
Gets all tasks


