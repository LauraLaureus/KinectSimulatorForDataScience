pointsInSpace <-read.csv("/Users/lala/TFM/KinectSimulatorForDataScience/Datasets/planeobject.csv")
profile <- pointsInSpace[,2:3]
colnames(profile) <- c("y","z")
plot(profile$z, profile$y)
