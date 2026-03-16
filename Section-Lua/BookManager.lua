-- Get UI references from StarterGui
local BookUI = script.Parent.Background
local Toolbar = BookUI.Toolbar
local Images = BookUI.Images
local NextButton = Toolbar.Next
local PrevButton = Toolbar.Prev
local Caption = Toolbar.Caption

-- Collect all images into an array
local imageArray = {}
for _, child in ipairs(Images:GetChildren()) do
	if child:IsA("ImageLabel") or child:IsA("ImageButton") then
		table.insert(imageArray, child)
	end
end

-- Initialize variables
local currentIndex = 1
local totalImages = #imageArray

-- Function to update the displayed image
local function updateImage()
	-- Hide all images first
	for _, image in ipairs(imageArray) do
		image.Visible = false
	end

	-- Show the current image
	local currentImage = imageArray[currentIndex]
	if currentImage then
		currentImage.Visible = true
		-- ONLY CHANGE: Get the Text StringValue value
		Caption.Text = currentImage.text.value
	end

	-- Update button visibility
	PrevButton.Visible = currentIndex > 1
	NextButton.Visible = currentIndex < totalImages
end

-- Button click handlers
local function onNextClick()
	if currentIndex < totalImages then
		currentIndex = currentIndex + 1
		updateImage()
	end
end

local function onPrevClick()
	if currentIndex > 1 then
		currentIndex = currentIndex - 1
		updateImage()
	end
end

-- Connect events
NextButton.MouseButton1Click:Connect(onNextClick)
PrevButton.MouseButton1Click:Connect(onPrevClick)

-- Initialize the UI
updateImage()
BookUI.Visible = true