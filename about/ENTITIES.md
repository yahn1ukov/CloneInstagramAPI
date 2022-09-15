# :page_with_curl: Entities

## Enums

|Name|Values|
|-|-|
|`UserRole`|`ADMIN`, `USER`|
|`UserGender`|`MALE`, `FEMALE`|

## Entities

### :heavy_check_mark: User

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`Email`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:||
|`FullName`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`Username`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:||
|`PasswordHash`|`byte[]`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`PasswordSalt`|`byte[]`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`Role`|`UserRole`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`USER`|
|`Avatar`|`string`|:x:|:x:|:heavy_check_mark:|:x:|:x:|`null`|
|`WebSite`|`string`|:x:|:x:|:heavy_check_mark:|:x:|:x:|`null`|
|`PhoneNumber`|`string`|:x:|:x:|:heavy_check_mark:|:x:|:x:|`null`|
|`Biography`|`string`|:x:|:x:|:heavy_check_mark:|:x:|:x:|`null`|
|`Gender`|`UserGender`|:x:|:x:|:heavy_check_mark:|:x:|:x:|`null`|
|`IsBanned`|`boolean`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`false`|
|`IsDeactivated`|`boolean`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`false`|
|`CreatedAt`|`DateTimeOffset`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`UtcNow`|

### :heavy_check_mark: Post

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`Content`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`Description`|`string`|:x:|:x:|:heavy_check_mark:|:x:|:x:||
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`CreatedAt`|`DateTimeOffset`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`UtcNow`|

### :heavy_check_mark: Like

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`PostId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||

### :heavy_check_mark: Save

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`PostId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||

### :heavy_check_mark: Comment

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`Message`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`PostId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`CreatedAt`|`DateTimeOffset`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`UtcNow`|

### :heavy_check_mark: Follower

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`FollowingUserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||

### :heavy_check_mark: Room

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`PenPalUserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||

### :heavy_check_mark: Message

|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|
|`Id`|`Guid`|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|`NewGuid`|
|`Message`|`string`|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|`UserId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`RoomId`|`Guid`|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|`IsEdited`|`bool`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`false`|
|`CreatedAt`|`DateTimeOffset`|:x:|:x:|:x:|:heavy_check_mark:|:x:|`UtcNow`|
