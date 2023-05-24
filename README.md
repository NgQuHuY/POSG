
# Demo report for NT204 
Đây là chương trình trả về kết quả số liệu của mô hình Partially Observable Stochastic Game (POSG) để phát hiện botnet trên mô hình mạng Erdos-Renyi random graph với số lượng node Infected devices khởi tạo là 19





## File
Cấu trúc file của chương trình như sau : 
- /Action

    - Attacker.cs : chứa hàm định nghĩa cho 2 kiểu tấn công Broadcast và Unicast và các hàm hỗ trợ
    - Defender.cs : chứa hàm định nghĩa cho 2 chiến thuật RDS và k-SDS được đề xuất trong bài báo và các hàm hỗ trợ

- /State

    - Initiate.cs : gồm 1 class Init có chức năng khởi tạo tham số cho 19 Infected node và random các node và edge kết nối dựa trên mô hình Erdos-Renyi 
    - Setup.cs : Tạo ra trạng thái đầu tiên của của các node mạng ở time-slot đó : Attacker tìm các edge để thực hiện lây lan và Defender chọn edge để đặt honeypot
    - Stage1.cs : Trả về kết quả của Setup : 2 node của edge có cả thuộc tính honeypot(def) và probagate(att) sẽ chuyển về state S. Ngược lại nếu chỉ có probagate chuyển node S về state I
    - State2.cs : Kết thúc State 1, các node I có 10% xác suất để chuyển về state S, các node S có 20% xác xuất để chuyển sang state R

- /Variable

    - Constanst.cs : Chứa các định nghĩa của các biến const (để dễ code)
    - Edge_Node.cs : Định nghĩa cho class Edge và Node và hàm khởi tạo của nó
    - ErdosRenyi.cs : Định nghĩa cho class ErdosRenyiGenerator để tạo ra mô hình ErdosRenyi theo số lượng node (n) và xác xuất cạnh của mỗi node (p)

- Main.cs : file chương trình chính, tương ứng với mỗi option attack và defense strategies để chạy mô hình 500 lần và trả về hai kết quả : trung bình số timeslot cần để botnet kết thúc và số lượng node I nhiều nhất
 
## Giao diện chương trình
<img width="387" alt="Screenshot 2023-05-25 000748" src="https://github.com/NgQuHuY/POSG/assets/105098386/77bacf3c-b075-4c91-9223-0a0e7b30e318">


## Kết quả Demo
Kết quả chạy của chương trình khác với kết quả mà tác giả đã đưa ra trong bài báo nên tụi em không rõ do source code có thuật toán sai hay mô hình demo khác với mô hình của tác giả
