# NationalTheaterWebApplication

The application should have two types of users (a cashier user represented and an administrator) which must provide a username and a password to use the application.

The administrator user can perform the following operations:
- CRUD on cashiers’ information.
- CRUD on the list of shows that are performed at the theater. Keep track of the Genre (Opera, Ballet), Title, Distribution list (a long string is enough), Date of the show and the Number of tickets per show.
- He/she can export all the tickets that were sold for a certain show (either in a csv or xml file).

The cashier can perform the following operations:
- Sell tickets to a show. A ticket should hold information about the seat row and seat number.
- The system should notify the cashier that the number of tickets per show was not exceeded when trying to book a new seat.
- A cashier can see all the tickets that were sold for a show, cancel a reservation or edit the reserved seat.

Application Constraints
- The data will be stored in a database. Make sure the database schema is designed to avoid redundancy.
- Use the Layers architectural pattern to organize your application. Use the following layers: Presentation (API) / Services for BL / Repositories
- The application should use Dependency Injection for separation of layers
- Use factory method for export to csv or xml.
