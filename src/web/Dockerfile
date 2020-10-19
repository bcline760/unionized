FROM node:current-alpine3.12 AS build
WORKDIR /
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.19.3-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /dist/unionized-web /usr/share/nginx/html