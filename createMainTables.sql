CREATE TABLE IF NOT EXISTS users
(
    id            INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    username      VARCHAR(31) UNIQUE  NOT NULL,
    email         VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255)        NOT NULL,
    password_salt VARCHAR(255)        NOT NULL,
    created_at    TIMESTAMP           NOT NULL,
    last_login_at TIMESTAMP,
    avatar        VARCHAR(1000)
);

CREATE TABLE IF NOT EXISTS profiles
(
    id          INTEGER PRIMARY KEY REFERENCES users (id),
    description TEXT
);

CREATE TABLE IF NOT EXISTS tasks
(
    id                INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    title             VARCHAR(63)  NOT NULL,
    author_id         INT          NOT NULL REFERENCES users (id),
    short_description VARCHAR(255) NOT NULL,
    full_description  TEXT,
    created_at        TIMESTAMP    NOT NULL,
    code_example      TEXT
);

CREATE TABLE IF NOT EXISTS solutions
(
    id                  INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    task_id             INT       NOT NULL REFERENCES tasks (id),
    author_id           INT       NOT NULL REFERENCES users (id),
    created_at          TIMESTAMP NOT NULL,
    is_current          BOOLEAN   NOT NULL,
    version_description VARCHAR(255),
    from_solution       INT,
    html                TEXT,
    css                 TEXT,
    js                  TEXT
);

CREATE TABLE IF NOT EXISTS task_comments
(
    id           INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    author_id    INT NOT NULL REFERENCES users (id),
    task_id      INT NOT NULL REFERENCES tasks (id),
    comment_text VARCHAR(4095)
);

CREATE TABLE IF NOT EXISTS task_likes
(
    id        INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    author_id INT NOT NULL REFERENCES users (id),
    task_id   INT NOT NULL REFERENCES tasks (id)
);

CREATE TABLE IF NOT EXISTS solution_comments
(
    id           INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    author_id    INT NOT NULL REFERENCES users (id),
    solution_id  INT NOT NULL REFERENCES solutions (id),
    comment_text VARCHAR(4095)
);

CREATE TABLE IF NOT EXISTS solution_likes
(
    id          INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    author_id   INT NOT NULL REFERENCES users (id),
    solution_id INT NOT NULL REFERENCES solutions (id)
);