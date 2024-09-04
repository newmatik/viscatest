# viscatest

`viscatest` is a .NET console application that communicates with a SONY VISCA-compatible camera via a serial (COM) port. This application allows the user to control camera zoom, focus, and iris settings using keyboard inputs. The zoom operates at maximum speed, and the program uses standard VISCA protocol commands.

## Features

- **Zoom Control**: 
  - Zoom in at maximum speed using the `+` key.
  - Zoom out at maximum speed using the `-` key.
  - Stop zoom using the `Z` key.
  
- **Focus Control**: 
  - Focus far using the `F` key.
  - Focus near using the `N` key.
  - Stop focus using the `X` key.

- **Iris Control**: 
  - Increase iris using the `I` key.
  - Decrease iris using the `K` key.

- **Camera Connection Test**: 
  - The application sends an inquiry command to the camera on startup to verify communication.

## Requirements

- .NET 6.0 SDK or higher
- Serial (COM) port connected to a SONY VISCA-compatible camera
- Windows or Linux machine with a serial port or USB-to-serial adapter

## How to Use

1. **Clone the repository:**

    ```bash
    git clone https://github.com/newmatik/viscatest.git
    cd viscatest
    ```

2. **Open the project in Visual Studio** or build the application from the command line using the .NET CLI:

    ```bash
    dotnet build
    ```

3. **Run the application**:

    Ensure the camera is connected to the specified COM port (default is `COM5`, but you can modify it in the source code).

    ```bash
    dotnet run
    ```

4. **Control the Camera**:

    After the connection is established, the application will display a list of available commands:

    ```
    === Camera Control Commands ===
    Press + to Zoom In (Maximum Speed)
    Press - to Zoom Out (Maximum Speed)
    Press Z to Stop Zoom
    Press F to Focus Far
    Press N to Focus Near
    Press X to Stop Focus
    Press I to Increase Iris
    Press K to Decrease Iris
    Press ESC to exit
    =================================
    ```

5. **Exit** the application by pressing the `ESC` key.

## Configuration

If your camera is connected to a different COM port, modify the following line in the `Main` method:

```csharp
_serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Copyright

(c) Newmatik GmbH
