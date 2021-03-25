Сonsole file storage that supports one user and the ability to download/manipulate files.

Application's configuration can be changed manualy with appsettings.json.

To change user related data edit "Login" and "Password". 
Default values "Login": "Vorobey", "Password": "v".
Edit "Storage path" on appsettings.json to change storage folder.
Edit "Metainf path" on appsettings.json to change location of Metadata.bin file.

Available commands: 
1) user login --l <login> --p <password> — execution of this command is requiried to use
other features.
To login with deafult login and password execute "user login --l Vorobey --p v"
2) file upload <path-to-file> - upload located on path-to-file file to storage folder.
3) file download <file-name> <destination-path> - download a file named file-name from
storage to the destination-path directory.
4) file move <source-file-name> <destination-file-name> - rename a file in storage.
5) file remove <file-name> - remove file-name from storage.
6) file info <file-name - display information about the file file-name on console.
7) user info - display user information