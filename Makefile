GODOT=D:\Applications\Computing\Godot\Godot_v4.0-rc3_mono_win64\Godot_v4.0-rc3_mono_win64.exe
DEBUG_CONNECT_TO=127.0.0.1

release:
	echo "Starting export"
	$(GODOT) --export-release "Windows Desktop"

dedicated:
	echo "Starting dedicated server..."
	$(GODOT) --dedicated

host:
	echo "Starting dedicated server..."
	$(GODOT) --host

debug_join:
	echo "Starting client and connecting..."
	$(GODOT) --connect $(DEBUG_CONNECT_TO)

start:
	echo "Starting client"
	$(GODOT)

