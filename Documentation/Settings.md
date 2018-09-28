# Settings
## Mail accounts
### Create mail account
```mermaid
sequenceDiagram
participant ViewModel
participant MailAccountManager
participant MailAccountService
participant UnitOfWork

MailAccountManager->>ViewModel: CreateNewMailAccount
MailAccountService->>MailAccountManager: CreateNew
ViewModel-->>ViewModel: UpdateMailAccount
ViewModel->>MailAccountManager: SaveMailAccount
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTMwNzIzOTkyNiwtMTk4Njk0MDQzMF19
-->