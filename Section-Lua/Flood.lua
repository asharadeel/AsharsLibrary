-- flood

local host = script.Parent
local trigger = host.FloodTrigger.ClickDetector
local flood = host.Flood
local music = host.FloodSound
local musicPlaying = false
local barrier = host.Barrier

local function floodScene()
	while true do	
		
		flood.Size = Vector3.new(flood.Size.X, flood.Size.Y + 0.5, flood.Size.Z)
		flood.Position = Vector3.new(flood.Position.X, flood.Position.Y + 0.25, flood.Position.Z)
		barrier:Destroy()
		
		if(musicPlaying == false) then
			music:Play()
			music.Looped = true
			musicPlaying = true
			trigger.Parent:Destroy()
		end
		
		wait(1.5)

		if flood.Size.Y > 80 then
			
			music:Stop()
			break
		end
	end
end

trigger.MouseClick:Connect(floodScene)