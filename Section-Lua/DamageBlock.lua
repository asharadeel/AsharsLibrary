--fire damage

function onTouch(part) 
	local humanoid = part.Parent:FindFirstChild("Humanoid") 
	if (humanoid ~= nil) then	-- if a humanoid exists, then
		part.Color = Color3.fromRGB(0, 0, 0)
	humanoid.Health = humanoid.Health -10	-- damage the humanoid
end 
end

script.Parent.Touched:connect(onTouch)

--Made By XxAtrocity
--Edited By GilianoBR3
