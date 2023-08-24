# Redis Listener

This project is a C# console application designed to monitor messages on Redis. It's bundled with a Dockerfile and a docker-compose.yml file to enable easy setup and configuration.

## Features

- Monitor messages on a specified Redis host.
- Configure the message topic you want to listen to.
- View the objects received from the Redis listener.
- Open source and easily customizable for your needs.

## How to Run

### Running Locally

You can run this project in any IDE by simply running it as any C# console project would run. Just open the solution and hit run.

### Running with Docker

You can run the project using Docker. First, you'll need to build the image:

```bash
docker build -t Redis-Listener:latest .
```

Then you can run the project using the `docker-compose.yml` file, making sure to modify it with the appropriate Redis host and other configurations:

```bash
docker-compose up
```

## Customizing

Feel free to fork this repository or clone it locally to modify the code according to your needs. The main entry point for the project is in the `Program.cs` file, and the Redis listener logic is found in the `RedisListener.cs` file.

## License

This is an open-source project, and it's available for anyone's needs. You can modify it and use it as you see fit.

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

## Support

For any questions or support, please open an issue in the GitHub repository.
