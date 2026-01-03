# Stage 1: Build the application
FROM node:18-alpine as builder

WORKDIR /app

COPY package*.json ./
RUN npm install && npm cache clean --force
COPY . .
RUN npm run build

# Stage 2: Production stage using a lightweight web server
FROM nginx:alpine

# Copy the built files from the builder stage to the Nginx web server directory
COPY --from=builder /app/dist /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
