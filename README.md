# InnoClinic

Development of a system for a medical center with several branches in the city.

## Requirements

.NET SDK 8.0 ([download .NET](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
PostgreSQL ([download PostgreSQL](https://www.postgresql.org/download/))
Git ([download Git](https://git-scm.com/downloads))

## Usage examples

* Patient.

The user should be able to create his account, make an appointment to the appropriate specialist or service, view his medical history and all additional opportunities related to the main cases.
* Admin+Doctor

The administrator should be able to view and manage appointments, create profiles for any kind of users.
The doctor should be able to view his schedule, fill in the data on the patient's appointment, view the patient's medical history and all the results of other appointments.

## Installation

1. Clone the repository
```bash
git clone https://github.com/MaksimDubat/InnoClinic
```

## Useful commands

Build the project:
```bash
dotnet build
```
Run the project:
```bash
dotnet run
```
Update the database:
```bash
dotnet ef database update
```
Check that the required NuGet packages are installed:
```bash
dotnet restore
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
