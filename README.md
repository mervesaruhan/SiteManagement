----There are 2 types of users: Managers and Apartment Owners/Tenants----

*Managers can perform the following actions:

-Create, update, or delete information of residents.
-Assign fees for each apartment either individually or in bulk.
-Enter monthly bills for the building (Electricity/Water/Gas).
-View payments made by apartments.
-See the debt status for each apartment on a monthly or yearly basis.

*Apartment Owners/Tenants can perform the following actions:

-View assigned bill and fee details.
-Make payments for fees or bills.
-Apartment Information:

*Block information
-Occupancy status (Occupied/Vacant)
-Type (e.g., 2+1)
-Floor
-Apartment number
-Owner or tenant details

*User Information:
- and surname
-National ID number
-Email
-Phone number
-Payment Information:

Payment method (Credit Card/Cash)
Payment date
Payment type (Fee/Bill: Electricity, Water, Gas)
Amount
Year and month of the payment
Details of which user made the payment for which apartment
Project Workflow:

*Manager Stage:

-When the system is first set up, if no manager exists, a user with a manager role is automatically created.
-To manage apartments, the manager logs in using the automatically generated username and password to obtain a JWT token.
-The manager enters all apartment and user (owner or tenant) information, then assigns each apartment to a user.
-The manager enters monthly fee and bill information.
-The manager can view the payment status for each user individually or check the building's overall paid/unpaid fees and bills.

*User Stage:

-Users (owners or tenants) can log in using their National ID number and phone number (no SMS verification required).
-Users can view their paid and unpaid bills and fees on a monthly basis.
-Users can make payments for fees or bills

*Rules:

-Only one user can be assigned to each apartment.




![README_SITE MANEGEMENT](https://github.com/user-attachments/assets/d84a1867-75a4-486c-b909-a9dea29a5ae2)
