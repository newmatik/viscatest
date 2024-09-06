# viscatest

**viscatest** is a .NET console application designed to communicate with SONY VISCA-compatible cameras via a serial (COM) port. The application allows users to control camera zoom, focus, and iris settings using simple keyboard inputs. The zoom functionality operates at maximum speed, and all communication is based on standard VISCA protocol commands.

**Note**: This is a work-in-progress project and is not production-ready.

## Prerequisites

- .NET 8.0 SDK or higher
- Visual Studio 2022 or later
- **NuGet Package**: `System.IO.Ports`
- Serial (COM) port connected to a SONY VISCA-compatible camera

## Installation and Setup

1. Clone the repository to your local machine.
2. Open the project in **Visual Studio 2022**.
3. Install the required NuGet package `System.IO.Ports`. You can do this via the **NuGet Package Manager** or run the following command in the **Package Manager Console**:

    ```
    Install-Package System.IO.Ports
    ```

4. **Note**: The COM port is hardcoded to `COM5` in the application. You may need to change this based on your setup.

## How to Run

1. Open the solution in **Visual Studio 2022**.
2. Build the solution (`Ctrl + Shift + B`).
3. Run the project (`F5`).

## Key Bindings

| Key   | Action                          |
|-------|---------------------------------|
| `+`   | Zoom in at maximum speed        |
| `-`   | Zoom out at maximum speed       |
| `Z`   | Stop zoom                       |
| `F`   | Focus far                       |
| `N`   | Focus near                      |
| `X`   | Stop focus                      |
| `I`   | Increase iris                   |
| `K`   | Decrease iris                   |
| `ESC` | Exit the application            |

## Known Issues

- **Command Piling**: Commands may pile up if keys are held down too long.
- **COM Port**: The COM port is hardcoded to `COM5`. Users need to change this manually if their machine is connected to a different port.
- **Work in Progress**: The project is still in development and is not production-ready.

## License

This project is licensed under the MIT License.

## Copyright

Copyright (c) 2024 Newmatik GmbH  
Am Markt 1, 55619 Hennweiler, Germany  
software@newmatik.com, www.newmatik.com
