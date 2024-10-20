

# Simple Switcher: Channel Manager

**Simple Switcher** is a C# application for managing source and destination channels, specifically for media streaming or network data routing. It maintains a list of channels, each defined by a name, IP address, and port, and allows for the modification, addition, or removal of channels.

## Features

- **Channel Management**: 
  - Manages source and destination channels as lists.
  - Supports adding, editing, and removing channels.
  - Channels are represented in the format: `Name:IP:Port`.
- **Data Persistence**: 
  - Channel data is saved to `.can` files (`chsrcs.can` for source channels, `chdest.can` for destination channels).
  - On startup, channels are loaded from these files or initialized with default values if the files do not exist.
- **Channel Attributes**: Allows retrieval and modification of specific channel attributes such as name, IP address, and port.

## Requirements

- **Operating System**: Windows
- **Framework**: .NET Framework 4.7.2+ or .NET Core 3.1+

## Setup

1. **Compile and Build**:
   - Use Visual Studio or another C# IDE to compile and build the solution.
   
2. **Run the Program**:
   - After building, run the executable file from the command line or directly from the IDE.

## Usage

- **Initialization**:
  - If the program doesn't find the files `chsrcs.can` or `chdest.can` in the current directory, it initializes with default channel data.
  - If the files exist, it loads channel data from them.

- **Channel Operations**:
  - **Add Channel**: Add a new source or destination channel by specifying its name, IP, and port.
  - **Edit Channel**: Modify specific attributes (name, IP, port) of a source or destination channel.
  - **Remove Channel**: Remove a channel from the list based on its index.
  - **Save Changes**: Any modification automatically marks the channel list as modified and triggers saving to disk.

- **Channel Information**:
  - Use the `get_Channel_Information` method to retrieve channel details, specifying the type (source/destination), index, and attribute (0 for name, 1 for IP, 2 for port).
  - Use the `set_Channel_Information` method to modify channel details, specifying the same parameters along with the new value.

## Example Operations

1. **Adding a New Channel**:
   ```csharp
   Channels_Manager manager = new Channels_Manager();
   manager.add_Channel("Sources", "New Channel", "239.0.0.1", 8000);
   ```

2. **Editing a Channel's IP**:
   ```csharp
   manager.set_Channel_Information("Sources", 0, 1, "239.0.0.2");
   ```

3. **Removing a Channel**:
   ```csharp
   manager.Remove_Channel("Destinations", 2);
   ```

4. **Saving Changes**:
   ```csharp
   manager.Save_Data();
   ```

## File Structure

- **Source Channels File (`chsrcs.can`)**:
  - Stores a list of source channels in the format `Name:IP:Port`.
- **Destination Channels File (`chdest.can`)**:
  - Stores a list of destination channels in the same format.

## Limitations

- Only supports basic list operations, so any concurrent modifications are not handled.
- Designed for simple use cases and may require adjustments for large-scale implementations or advanced networking setups.

## Notes

- **Data Persistence**: Channel lists are automatically saved to `.can` files upon modification.
- **Default Values**: Initial channel lists contain predefined values, which are
