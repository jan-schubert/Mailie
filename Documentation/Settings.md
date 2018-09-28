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
MailAccountService->>MailAccountManager: CreateNewMailAccount
ViewModel->>MailAccountManager: SaveMailAccount
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTgxMzY5ODQ1LC0xOTg2OTQwNDMwXX0=
-->