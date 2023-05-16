# Project Solution

The design choices for this project were driven by an anticipated future growth and the need for scalability. The chosen architecture reflects a solution capable of managing complex business requirements, while also allowing for straightforward maintenance and scalability.

## Backend: .NET Core with Clean Architecture and CQRS Pattern

For the backend, I selected **.NET Core** due to its cross-platform support, superior performance, and excellent tooling. It is a mature framework that is ideal for constructing large systems.

I implemented the **clean architecture** due to its focus on the separation of concerns. Business logic and domain entities are centrally managed, ensuring their independence from specific infrastructure components like databases and external libraries. This design approach helps in maintaining the system's manageability as it scales and evolves.

Additionally, I employed the **CQRS (Command Query Responsibility Segregation) pattern** alongside the **mediator pattern**, implemented with the **MediatR library**. The CQRS pattern simplifies application design by differentiating between read and write operations, thus allowing for independent scaling of both. This provides flexibility and facilitates a more optimized system. The mediator pattern, implemented through MediatR, assists in reducing coupling and enhancing the maintainability of the system. It ensures indirect interaction between objects, simplifying modifications and understanding.

## Frontend: Next.js and TanStack Query (React Query)

I chose **Next.js** for the frontend due to its server-side rendering capabilities and the robust structure it provides to the project. As the application grows, it can leverage Next.js's multitude of features like automatic code splitting and route pre-fetching. This structured approach not only makes the application scalable but also ensures a high-performing and SEO-friendly frontend.

For data fetching, I used **React Query (TanStack)**. As the application primarily deals with server-state, React Query is an ideal fit. It provides powerful features such as caching, synchronization, and background updates. I leveraged its infinite queries feature to implement infinite loading of jobs, which significantly enhances user experience and application performance.

## Styling: Tailwind CSS

For styling, I selected **Tailwind CSS**. It adopts a utility-first approach that promotes component reusability and consistency across the application. Moreover, it is highly customizable, allowing the design to be specifically tailored to the project's requirements.

## Unclear Areas

Currently, the API is public. I did not implement authentication and authorization as it was assumed to be out of scope for this project. However, in a real-world application, implementing these security measures is paramount.

Given the provided database structure, I grouped related properties (`contact_name`, `contact_phone`, `contact_email`) into a value object to describe a contact detail. However, there could be scenarios where it would make sense to model Contact as an entity depending on the other business requirements.

## Future Improvements

Given more time, there are several enhancements that could further improve the project:

**Testing:** Implementing comprehensive unit and integration tests would be a priority. These tests would provide confidence in the system's correctness and robustness, making it easier to add new features or make changes in the future.

**Cross-Cutting Concerns:** Improvements in cross-cutting concerns such as logging, API versioning, and exception handling would be beneficial. Enhanced logging would aid in identifying and rectifying issues, while API versioning would ensure backward compatibility as the application evolves. Better exception handling could make the system more resilient and user-friendly.

**User Experience:** On the frontend, I would enhance the user experience by adding features like confirmation popups and animations, making the application more interactive and engaging.

## Instructions to Run
1. Make sure you have installed Docker and it is running on your local machine.
2. In the root folder, run the following command.
 ```
 docker-compose up -d
 ```
3. This will create and run three containers for the backend service, UI application and the mySQL database.
4. You can now access the UI via http://localhost:3000
