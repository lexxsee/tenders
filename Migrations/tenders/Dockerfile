FROM  flyway/flyway
COPY /flyway /flyway
ENTRYPOINT ls -lR /flyway/sql && \
 /flyway/flyway baseline migrate info -user=${DB_USER} -password=${DB_PASSWORD} -url=${DB_URL} -connectRetries=300