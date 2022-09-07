# :page_with_curl: Endpoints

**Total:** ```29```

|URL|Method|Role|Input|Output|
|-|-|-|-|-|
|```/api/authentication/login```|```POST```|```ANONYMOUS```|```{```<br/>&emsp;```Username: string```<br/>&emsp;```Password: string```<br/>```}```|```{```<br/>&emsp;```Token: string```<br/>&emsp;```Role: string```<br/>```}```|
|```/api/authentication/registration```|```POST```|```ANONYMOUS```|```{```<br/>&emsp;```Username: string```<br/>&emsp;```FullName: string```<br/>&emsp;```Email: string```<br/>&emsp;```Password: string```<br/>```}```|```true```|
|```/api/admins/users```|```GET```|```ADMIN```||```IEnumerable<User>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Email: string```<br/>&emsp;&emsp;```FullName: string```<br/>&emsp;&emsp;```Username: string```<br/>&emsp;&emsp;```Role: string```<br/>&emsp;&emsp;```Gender: string/null```<br/>&emsp;&emsp;```Avatar: string/null```<br/>&emsp;&emsp;```CreatedAt: DateTimeOffset```<br/>&emsp;```}```<br/>```]```|
|```/api/admins/posts```|```GET```|```ADMIN```||```IEnumerable<Post>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Content: string```<br/>&emsp;```}```<br/>```]```|
|```/api/admins/users/{userId}```|```GET```|```ADMIN```|```Id: Guid```|```{```<br/>&emsp;```Id: Guid```<br/>&emsp;```Email: string```<br/>&emsp;```FullName: string```<br/>&emsp;```Username: string```<br/>&emsp;```Avatar: string/null```<br/>&emsp;```WebSite: string/null```<br/>&emsp;```PhoneNumber: string/null```<br/>&emsp;```Biography: string/null```<br/>```}```|
|```/api/admins/users/{userId}```|```PATCH```|```ADMIN```|```Id: Guid```<br/><br/>```{```<br/>&emsp;```NewRole: int```<br/>```}```|```true```|
|```/api/admins/users/{userId}/ban```|```PATCH```|```ADMIN```|```Id: Guid```|```true```|
|```/api/admins/users/{userId}/unban```|```PATCH```|```ADMIN```|```Id: Guid```|```true```|
|```/api/admins/users/{userId}```|```DELETE```|```ADMIN```|```Id: Guid```|```true```|
|```/api/admins/posts/{postId}```|```DELETE```|```ADMIN```|```Id: Guid```|```true```|
|```/api/users```|```GET```|```USER```|```Id: HttpContext```|```{```<br/>&emsp;```Id: Guid```<br/>&emsp;```Email: string```<br/>&emsp;```FullName: string```<br/>&emsp;```Username: string```<br/>&emsp;```Role: string```<br/>&emsp;```Gender: string/null```<br/>&emsp;```Avatar: string/null```<br/>&emsp;```CreatedAt: DateTimeOffset```<br/>```}```|
|```/api/users/{username}```|```GET```|```USER```|```Username: string```|```{```<br/>&emsp;```Id: Guid```<br/>&emsp;```Email: string```<br/>&emsp;```FullName: string```<br/>&emsp;```Username: string```<br/>&emsp;```Role: string```<br/>&emsp;```Gender: string/null```<br/>&emsp;```Avatar: string/null```<br/>&emsp;```CreatedAt: DateTimeOffset```<br/>```}```|
|```/api/users```|```PATCH```|```USER```|```Id: HttpContext```<br/><br/>```{```<br/>&emsp;```Avatar: string/null```<br/>&emsp;```FullName: string```<br/>&emsp;```Username: string```<br/>&emsp;```WebSite: string/null```<br/>&emsp;```Biography: string/null```<br/>&emsp;```Email: string```<br/>&emsp;```PhoneNumber: string/null```<br/>&emsp;```Gender: int/null```<br/>```}```|```true```|
|```/api/users/password```|```PATCH```|```USER```|```Id: HttpContext```<br/><br/>```{```<br/>&emsp;```OldPassword: string```<br/>&emsp;```NewPassword: string```<br/>&emsp;```ConfirmedNewPassword: string```<br/>```}```|```true```|
|```/api/users```|```DELETE```|```USER```|```Id: HttpContext```|```true```|
|```/api/posts```|```POST```|```USER```|```Id: HttpContext```<br/><br/>```{```<br/>&emsp;```Content: string```<br/>&emsp;```Description: string/null```<br/>```}```|```true```|
|```/api/posts```|```GET```|```USER```||```IEnumerable<Post>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Content: string```<br/>&emsp;```}```<br/>```]```|
|```/api/posts/users/{username}```|```GET```|```USER```|```Username: string```|```IEnumerable<Post>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Content: string```<br/>&emsp;```}```<br/>```]```|
|```/api/posts/users/{username}/likes```|```GET```|```USER```|```Username: string```|```IEnumerable<Post>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Content: string```<br/>&emsp;```}```<br/>```]```|
|```/api/posts/users/{username}/saves```|```GET```|```USER```|```Username: string```|```IEnumerable<Post>```<br/>```[```<br/>&emsp;```{```<br/>&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;```Content: string```<br/>&emsp;```}```<br/>```]```|
|```/api/posts/{postId}```|```GET```|```USER```|```Id: Guid```|```{```<br/>&emsp;```Id: Guid```<br/>&emsp;```Content: string```<br/>&emsp;```Description: string/null```<br/>&emsp;```Avatar: string/null```<br/>&emsp;```Username: string```<br/>&emsp;```CountLikes: int```<br/>&emsp;```CountSaves: int```<br/>&emsp;```CountComments: int```<br/>&emsp;```IEnumerable<Comment>```<br/>&emsp;```[```<br/>&emsp;&emsp;```{```<br/>&emsp;&emsp;&emsp;```Id: Guid```<br/>&emsp;&emsp;&emsp;```Message: string```<br/>&emsp;&emsp;&emsp;```Username: string```<br/>&emsp;&emsp;&emsp;```Avatar: string/null```<br/>&emsp;&emsp;&emsp;```CreatedAt: DateTimeOffset```<br/>&emsp;&emsp;```}```<br/>&emsp;```]```<br/>&emsp;```isLike: boolean```<br/>&emsp;```isSave: boolean```<br/>&emsp;```CreatedAt: DateTimeOffset```<br>```}```|
|```/api/posts/{postId}```|```PATCH```|```USER```|```Id: Guid```<br/><br/>```{```<br/>&emsp;```Description: string```<br/>```}```|```true```|
|```/api/posts/{postId}```|```DELETE```|```USER```|```Id: Guid```|```true```|
|```/api/posts/{postId}/like```|```POST```|```USER```|```Id: Guid```|```true```|
|```/api/posts/{postId}/unlike```|```DELETE```|```USER```|```Id: Guid```|```true```|
|```/api/posts/{postId}/save```|```POST```|```USER```|```Id: Guid```|```true```|
|```/api/posts/{postId}/unsave```|```DELETE```|```USER```|```Id: Guid```|```true```|
|```/api/posts/{postId}/comment```|```POST```|```USER```|```Id: Guid```<br/><br/>```{```<br/>&emsp;```Message: string```<br/>```}```|```true```|
|```/api/posts/{postId}/uncomment```|```DELETE```|```USER```|```Id: Guid```|```true```|
