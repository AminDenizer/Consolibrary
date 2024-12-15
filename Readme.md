# Library Management System

## Overview

The **Library Management System** is a console-based application developed in C#. It is designed to help libraries manage their book collections, members, and transactions. The system allows users to add books, register members, borrow books, and track transactions, making it a simple yet effective way to automate library management processes.

## Features

- **Add Books**: Users can add books with details like title, author, and genre.
- **Add Members**: Users can register new members by providing their name and ID.
- **Borrow Books**: Members can borrow books from the library.
- **View Books**: View a list of all available books in the library.
- **View Members**: View a list of all registered library members.
- **View Transactions**: Track the borrow transactions.
- **Data Persistence**: Data is saved and loaded from files, so all changes are preserved across sessions.

## Prerequisites

To run this project, you'll need the following:

- [Visual Studio](https://visualstudio.microsoft.com/) or any C# IDE.
- [.NET SDK](https://dotnet.microsoft.com/download) for compiling and running the application.

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/AminDenizer/Consolibrary.git
   ```

2. **Open the Project**:
   Open the `LibraryManagement.sln` file in Visual Studio or any other C# IDE.

3. **Restore Dependencies**:
   Visual Studio will automatically restore any missing dependencies when the project is opened.

4. **Build the Project**:
   In Visual Studio, go to `Build` > `Build Solution` or press `Ctrl + Shift + B`.

5. **Run the Project**:
   Press `Ctrl + F5` to run the application without debugging.

## Usage

Once the program is running, you will be presented with a menu offering the following options:

```
1. Add Book
2. Add Member
3. Borrow Book
4. View Books
5. View Members
6. View Transactions
0. Exit
```

### Menu Options

- **Add Book**: Users can add a book by providing its title, author, and genre.
- **Add Member**: Register a new member by providing their name and ID.
- **Borrow Book**: A member can borrow a book by specifying the book title and their member ID.
- **View Books**: Displays all books currently available in the library.
- **View Members**: Displays all registered members.
- **View Transactions**: Displays all borrowing transactions that have occurred in the library.
- **Exit**: Save all data and exit the program.

### Data Persistence

All data related to books, members, and transactions is automatically saved in files. When the program is restarted, it loads the saved data, ensuring that no information is lost between sessions.

## File Structure

The project includes the following key files:

- **Program.cs**: The main entry point of the application, responsible for displaying the menu and handling user input.
- **Book.cs**: Contains the `Book` class, which stores the details of a book such as its title, author, and genre.
- **Member.cs**: Contains the `Member` class, which stores information about a library member (name and ID).
- **Transaction.cs**: Contains the `Transaction` class, which stores information about book borrowings (which member borrowed which book and when).
- **Library.cs**: Manages the collection of books, members, and transactions. It also includes methods for adding books, members, and borrowing books.
- **FileManager.cs**: Handles reading from and writing to files to persist data between sessions.

## Docker Usage

### 1. Download (Pull) Docker Image

To download the Docker image from GitHub Container Registry, use the following command:

```bash
docker pull ghcr.io/amindenizer/consolibrary:latest
```

This command will download the latest version of the image with the `latest` tag.

### 2. Execute (Run) Docker Container

To run the Docker container from the downloaded image, use the following command:

```bash
docker run -it ghcr.io/amindenizer/consolibrary:latest
```

This command will run the downloaded image in an interactive container.

## License

This project is open-source and available under the [MIT License](LICENSE).

## Contributing

If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your changes to your fork.
5. Create a pull request to contribute your changes.

## Acknowledgments

- Developed by **Amin Denizer**.
- Special thanks to [Visual Studio](https://visualstudio.microsoft.com/) for providing an excellent development environment.
- This project was built as an educational tool to demonstrate basic concepts of library management systems.
```

This version includes everything in English, including the sections related to Docker usage and all the necessary setup and instructions for the Library Management System project. Let me know if you need further adjustments!