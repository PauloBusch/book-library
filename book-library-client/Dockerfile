FROM node:22-alpine

WORKDIR /app

COPY book-library-client/package.json .

RUN npm install

COPY book-library-client .

EXPOSE 3000

CMD ["npm", "run", "dev"]