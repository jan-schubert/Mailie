# Settings
## Mail accounts
### Create mail account
```mermaid
sequenceDiagram
participant ViewModel
participant MailAccountManager
participant qq


MailAccountManager->>ViewModel: CreateNewMailAccount
ViewModel->>MailAccountManager: SaveMailAccount
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5ODY5NDA0MzBdfQ==
-->