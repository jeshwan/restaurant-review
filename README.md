# Restaurant Review Application

## Overview

The Restaurant Review application simplifies the process of selecting a restaurant by enabling users to leave reviews for various establishments. With features such as user management, restaurant details display, and review addition, it provides a user-friendly experience for both restaurant-goers and administrators.

## Functionality

- **Add a New User:**
  - Users can register and create a new account.

- **Search User (Admin):**
  - Admins have the optional ability to search for users.

- **Display Restaurant Details:**
  - Users can view details of a specific restaurant.

- **Add Reviews to a Restaurant:**
  - Users can leave reviews for restaurants.

- **View Restaurant Details:**
  - Users can see general information about a restaurant.

- **View Reviews of Restaurants:**
  - Users can browse reviews submitted by others for a restaurant.

- **Calculate Reviews’ Average Rating:**
  - The system calculates the average rating for each restaurant based on user reviews.

- **Search Restaurant:**
  - Users can search for restaurants based on criteria like name, rating, zip code, etc.

## Suggested Models/Objects

- **User:**
  - Represents a registered user of the application.

- **Restaurant:**
  - Represents a restaurant with details such as name, location, and average rating.

- **Review:**
  - Represents a user's review for a specific restaurant.

*Note: Additional models or objects can be added based on design requirements.*

## Additional Requirements

- **Exception Handling:**
  - The application should handle exceptions gracefully.

- **Input Validation:**
  - Validate user inputs to ensure data integrity.

- **Data Persistence:**
  - Data should be persisted in the form of XML or JSON; no hard-coded data.

- **XML Documentation:**
  - Code should include XML documentation for better understanding.

## Tech Stack

- **C#:**
  - Primary programming language.

- **Exception Handling:**
  - Implement robust exception handling mechanisms.

- **Serialization (XML or JSON):**
  - Persist data in XML or JSON format.

- **Class Library:**
  - Separate projects for data and functionality using a class library.

- **Console App for UI:**
  - A console application to provide a simple user interface.

- **Solution Structure:**
  - A solution containing both the class library and console app projects.
