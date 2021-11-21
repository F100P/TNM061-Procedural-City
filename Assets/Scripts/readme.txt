Some notes on the terminology

Plot = This is a large prefab containing the terrain of the area, and also a number of spawners
Spawner = This is a placeholder object used to indicate where a random parcel is to be placed. Upon instantiation, the spawners will automatically replace themselves with parcels
Parcel = This is a small prefab containing one/several buildings or other props.

==USAGE==

The spawner scripts can simply be attached to any random object and they will run automatically. They are not dependent on any other scripts. You just need to assign a list of parcels in the inspector.

The randomize script is a bit of a misnomer; it doesn't really do much actual randomization, it just instantiates a random plot. Currently needs to be attached to a button, if you don't want to bother with that you can just move all the code in "OnButtonPress()" to "Start()". Like the spawner scripts, this needs a list of plots assigned in the inspector.