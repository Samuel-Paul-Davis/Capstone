CD ..
FOR /l %%i IN (1,1,100) DO (
	copy "colour4k.jpg" "colour4k(%%i).jpg"
	copy "colour4k.jpg.meta" "colour4k(%%i).jpg.meta"
)