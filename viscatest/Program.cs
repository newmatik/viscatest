using System;
using System.IO.Ports;
using System.Threading;

class ViscaCameraController
{
    private static SerialPort _serialPort;

    // VISCA Commands (Zoom, Focus, Iris)
    private static readonly byte[] ZoomInCommand = { 0x81, 0x01, 0x04, 0x07, 0x27, 0xFF };  // Zoom In at maximum speed
    private static readonly byte[] ZoomOutCommand = { 0x81, 0x01, 0x04, 0x07, 0x37, 0xFF };  // Zoom Out at maximum speed
    private static readonly byte[] StopZoomCommand = { 0x81, 0x01, 0x04, 0x07, 0x00, 0xFF }; // Stop Zoom

    private static readonly byte[] FocusNearCommand = { 0x81, 0x01, 0x04, 0x08, 0x03, 0xFF };  // Focus Near
    private static readonly byte[] FocusFarCommand = { 0x81, 0x01, 0x04, 0x08, 0x02, 0xFF };   // Focus Far
    private static readonly byte[] StopFocusCommand = { 0x81, 0x01, 0x04, 0x08, 0x00, 0xFF };  // Stop Focus

    private static readonly byte[] IrisUpCommand = { 0x81, 0x01, 0x04, 0x0B, 0x02, 0xFF };  // Iris Up
    private static readonly byte[] IrisDownCommand = { 0x81, 0x01, 0x04, 0x0B, 0x03, 0xFF }; // Iris Down

    private static readonly byte[] InquiryCommand = { 0x81, 0x09, 0x04, 0x00, 0xFF }; // Inquiry Command

    static void Main(string[] args)
    {
        // Initialize serial port connection
        _serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        try
        {
            _serialPort.Open();

            // Ensure the port is open
            if (_serialPort.IsOpen)
            {
                Console.WriteLine("Connected to the camera on COM5");

                // Send a basic inquiry to test if the camera responds
                if (TestConnection())
                {
                    Console.WriteLine("Connection to the camera verified successfully.");
                    ShowCommands();
                    ListenForCommands();
                }
                else
                {
                    Console.WriteLine("Failed to communicate with the camera.");
                    _serialPort.Close();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static bool TestConnection()
    {
        // Try sending an inquiry command to check if the camera responds
        try
        {
            SendCommand(InquiryCommand);

            // Small delay to give the camera time to respond
            Thread.Sleep(200);

            if (_serialPort.BytesToRead > 0)
            {
                // Reading the response from the camera
                byte[] buffer = new byte[_serialPort.BytesToRead];
                _serialPort.Read(buffer, 0, buffer.Length);
                Console.WriteLine("Camera responded to the inquiry command.");
                return true;
            }
            else
            {
                Console.WriteLine("No response from the camera.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during connection test: " + ex.Message);
            return false;
        }
    }

    private static void ShowCommands()
    {
        // Display available commands to the user
        Console.WriteLine("\n=== Camera Control Commands ===");
        Console.WriteLine("Press + to Zoom In (Maximum Speed)");
        Console.WriteLine("Press - to Zoom Out (Maximum Speed)");
        Console.WriteLine("Press Z to Stop Zoom");
        Console.WriteLine("Press F to Focus Far");
        Console.WriteLine("Press N to Focus Near");
        Console.WriteLine("Press X to Stop Focus");
        Console.WriteLine("Press I to Increase Iris");
        Console.WriteLine("Press K to Decrease Iris");
        Console.WriteLine("Press ESC to exit");
        Console.WriteLine("================================\n");
    }

    private static void ListenForCommands()
    {
        // Start listening for keypresses
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.OemPlus:  // + key for zoom in
                    SendCommand(ZoomInCommand);
                    Console.WriteLine("Zooming In at Maximum Speed...");
                    break;
                case ConsoleKey.OemMinus:  // - key for zoom out
                    SendCommand(ZoomOutCommand);
                    Console.WriteLine("Zooming Out at Maximum Speed...");
                    break;
                case ConsoleKey.Z:  // Stop zoom with Z key
                    SendCommand(StopZoomCommand);
                    Console.WriteLine("Zoom Stopped.");
                    break;
                case ConsoleKey.F:  // Focus far
                    SendCommand(FocusFarCommand);
                    Console.WriteLine("Focusing Far...");
                    break;
                case ConsoleKey.N:  // Focus near
                    SendCommand(FocusNearCommand);
                    Console.WriteLine("Focusing Near...");
                    break;
                case ConsoleKey.X:  // Stop focus
                    SendCommand(StopFocusCommand);
                    Console.WriteLine("Focus Stopped.");
                    break;
                case ConsoleKey.I:  // Iris up
                    SendCommand(IrisUpCommand);
                    Console.WriteLine("Iris Increasing...");
                    break;
                case ConsoleKey.K:  // Iris down
                    SendCommand(IrisDownCommand);
                    Console.WriteLine("Iris Decreasing...");
                    break;
            }

        } while (keyInfo.Key != ConsoleKey.Escape);

        // Close the serial port connection
        _serialPort.Close();
        Console.WriteLine("Disconnected from the camera.");
    }

    private static void SendCommand(byte[] command)
    {
        try
        {
            _serialPort.Write(command, 0, command.Length);
            Console.WriteLine("Command sent: " + BitConverter.ToString(command));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending command: " + ex.Message);
        }
    }
}
