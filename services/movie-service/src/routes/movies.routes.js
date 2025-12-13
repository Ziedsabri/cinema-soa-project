const express = require("express");
const router = express.Router();
const movies = require("../data/movies");

// GET all movies
router.get("/", (req, res) => {
  res.json(movies);
});

// GET movie by id
router.get("/:id", (req, res) => {
  const movie = movies.find((m) => m.id == req.params.id);
  if (!movie) {
    return res.status(404).json({ message: "Movie not found" });
  }
  res.json(movie);
});

module.exports = router;
