# Image officielle Node.js (stable)
FROM node:18

# Dossier de travail dans le conteneur
WORKDIR /app

# Copier package.json et package-lock.json
COPY package*.json ./

# Installer les dépendances
RUN npm install

# Copier le reste du code
COPY . .

# Exposer le port du service
EXPOSE 3001

# Lancer le service
CMD ["npm", "start"]
