CREATE TABLE IF NOT EXISTS users
(
    id            SERIAL PRIMARY KEY,
    username      VARCHAR(31) UNIQUE  NOT NULL,
    email         VARCHAR(255) UNIQUE NOT NULL,
    passwordHash  VARCHAR(255)        NOT NULL,
    created_at    TIMESTAMP           NOT NULL,
    last_login_at TIMESTAMP,
    avatar        VARCHAR(1000)
);

CREATE TABLE IF NOT EXISTS profiles
(
    id          INT PRIMARY KEY references users (id),
    description TEXT
);

CREATE TABLE IF NOT EXISTS tasks
(
    id                SERIAL PRIMARY KEY,
    title             VARCHAR(63)  NOT NULL,
    author_id         INT          NOT NULL references users (id),
    short_description VARCHAR(255) NOT NULL,
    full_description  TEXT,
    created_at        TIMESTAMP    NOT NULL,
    code_example      TEXT
);

CREATE TABLE IF NOT EXISTS solutions
(
    id                  SERIAL PRIMARY KEY,
    task_id             INT       NOT NULL references tasks (id),
    author_id           INT       NOT NULL references users (id),
    created_at          TIMESTAMP NOT NULL,
    is_current          BOOLEAN   NOT NULL,
    version_description VARCHAR(255),
    from_solution       INT,
    html                TEXT,
    css                 TEXT,
    js                  TEXT
);

CREATE TABLE IF NOT EXISTS comments
(
    id          SERIAL PRIMARY KEY,
    author_id   INT NOT NULL references users (id),
    solution_id INT NOT NULL references solutions (id),
    text        VARCHAR(4095)
);

CREATE TABLE IF NOT EXISTS solution_likes
(
    id          SERIAL PRIMARY KEY,
    author_id   INT NOT NULL references users (id),
    solution_id INT NOT NULL references solutions (id)
);

