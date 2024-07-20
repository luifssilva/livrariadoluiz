# Stage 1
FROM node:18.17.1 as build
WORKDIR /usr/local/app
COPY ./ /usr/local/app/
RUN npm install
RUN npm run build

# Stage 2
FROM nginx:latest
COPY --from=build /usr/local/app/dist/livrariadoluiz-front/browser /usr/share/nginx/html
EXPOSE 80