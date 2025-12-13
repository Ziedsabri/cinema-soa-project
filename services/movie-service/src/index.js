const express = require("express");
const cors = require("cors");

const movieRoutes = require("./routes/movies.routes");

const app = express();
app.use(cors());
app.use(express.json());

app.use("/movies", movieRoutes);

const PORT = 3001;
app.listen(PORT, () => {
  console.log(`🎬 Movie-Service running on port ${PORT}`);
});
