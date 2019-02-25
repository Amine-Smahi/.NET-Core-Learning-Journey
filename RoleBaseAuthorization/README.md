## What is Authorization
Authorization is a process that determines what a user is able to do. For example, an Admin user is allowed to install/remove a software from a computer and a non-Admin user can use the software from the computer. It is independent and orthogonal from authentication. However, authorization requires an authentication mechanism. For applications, the first step is always authentication and then authorization.

## What is Identity
Identity is membership system that allows us to add login functionality to our application and identity may belong to one or more roles. For Example, "User1" belongs to "Admin" role and "User2" belongs to "HR" role.

## So how it works
Using AuthorizeFilter, we can control the access in our MVC/Web API application by specifying this attribute in controller or action method. Role based authorization checks whether login user role has access to the page or not. Here developer embeds the roles with their code.

## How to create a user and assign a role
creating and assigning a role to a user is easy just

    user = new IdentityUser () {
    UserName = "Amine@Amine.com.com",
    Email = "Amine@Amine.com.com",
     };
    await UserManager.CreateAsync (user, "Test@123");
               
                
## Screenshot

![sc1](https://user-images.githubusercontent.com/24621701/44304537-323a5a00-a356-11e8-88f6-e2c34007bcb3.png)

![sc2](https://user-images.githubusercontent.com/24621701/44304536-31092d00-a356-11e8-9921-39296e8994dc.png)
