@echo off
echo Adding all files...
git add .

echo Committing changes...
git commit -m "Add Food Delivery API with database integration"

echo Setting main branch...
git branch -M main

echo Pushing to GitHub...
git push -u origin main

pause