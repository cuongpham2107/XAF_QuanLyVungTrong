
function init(dotNetHelper) {
    const styledMapType = new google.maps.StyledMapType(
        [
            { elementType: "geometry", stylers: [{ color: "#ebe3cd" }] },
            { elementType: "labels.text.fill", stylers: [{ color: "#523735" }] },
            { elementType: "labels.text.stroke", stylers: [{ color: "#f5f1e6" }] },
            {
                featureType: "administrative",
                elementType: "geometry.stroke",
                stylers: [{ color: "#c9b2a6" }],
            },
            {
                featureType: "administrative.land_parcel",
                elementType: "geometry.stroke",
                stylers: [{ color: "#dcd2be" }],
            },
            {
                featureType: "administrative.land_parcel",
                elementType: "labels.text.fill",
                stylers: [{ color: "#ae9e90" }],
            },
            {
                featureType: "landscape.natural",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "poi",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "poi",
                elementType: "labels.text.fill",
                stylers: [{ color: "#93817c" }],
            },
            {
                featureType: "poi.park",
                elementType: "geometry.fill",
                stylers: [{ color: "#a5b076" }],
            },
            {
                featureType: "poi.park",
                elementType: "labels.text.fill",
                stylers: [{ color: "#447530" }],
            },
            {
                featureType: "road",
                elementType: "geometry",
                stylers: [{ color: "#f5f1e6" }],
            },
            {
                featureType: "road.arterial",
                elementType: "geometry",
                stylers: [{ color: "#fdfcf8" }],
            },
            {
                featureType: "road.highway",
                elementType: "geometry",
                stylers: [{ color: "#f8c967" }],
            },
            {
                featureType: "road.highway",
                elementType: "geometry.stroke",
                stylers: [{ color: "#e9bc62" }],
            },
            {
                featureType: "road.highway.controlled_access",
                elementType: "geometry",
                stylers: [{ color: "#e98d58" }],
            },
            {
                featureType: "road.highway.controlled_access",
                elementType: "geometry.stroke",
                stylers: [{ color: "#db8555" }],
            },
            {
                featureType: "road.local",
                elementType: "labels.text.fill",
                stylers: [{ color: "#806b63" }],
            },
            {
                featureType: "transit.line",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "transit.line",
                elementType: "labels.text.fill",
                stylers: [{ color: "#8f7d77" }],
            },
            {
                featureType: "transit.line",
                elementType: "labels.text.stroke",
                stylers: [{ color: "#ebe3cd" }],
            },
            {
                featureType: "transit.station",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "water",
                elementType: "geometry.fill",
                stylers: [{ color: "#b9d3c2" }],
            },
            {
                featureType: "water",
                elementType: "labels.text.fill",
                stylers: [{ color: "#92998d" }],
            },
        ],
        { name: "Styled Map" }
    );
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 10,
        center: { lat: 22.510488, lng: 104.301703 },

        mapTypeControlOptions: {
            mapTypeIds: ["roadmap", "satellite", "hybrid", "terrain", "styled_map"],
        },
    });
    dotNetHelper.forEach(kq => {
       console.log(kq)
        // Define the LatLng coordinates for the polygon.
        const triangleCoords = [
            JSON.parse(kq.toaDo)
        ];
        // Construct the polygon.
        const poligonAll = new google.maps.Polygon({
            paths: triangleCoords,
            strokeColor: "#86efac",
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: "#84cc16",
            fillOpacity: 0.35,
        });

        poligonAll.setMap(map);
        // Add a listener for the click event.
        let popup = true;
        poligonAll.addListener("mouseover", (e) => showPopup(e, kq, popup = true));
        poligonAll.addListener("mouseout", (e) => showPopup(e, kq, popup = false));

        infoWindow = new google.maps.InfoWindow();

    })
    //Associate the styled map with the MapTypeId and set it to display.
    map.mapTypes.set("styled_map", styledMapType);
    map.setMapTypeId("styled_map");



}
function showPopup(event, data, popup) {
    const polygon = this;
    let contentString =
        `<div class="container">
            <div class="row">
                <div class="col-12 mt-2 mb-2">
                    <h2>Thông tin vùng trồng </h2>
                    <hr/>
                    <p class="h6">Tên vùng trồng: <span class="lead">${data.td}</span></p>
                    <p class="h6">Địa chỉ: <span class="lead">${data.diaChi}</span></p>
                    <p class="h6">Năm cấp: <span class="lead">${data.namCap}</span></p>
                    <p class="h6">Diện tích: <span class="lead">${data.dienTichCanhTac}</span></p>
                    <p class="h6">Hình thức canh tác: <span class="lead">${data.hinhThucCanhTac || 'Chưa có dữ liệu'}</span></p>
                    <p class="h6">Sản lượng dự kiến: <span class="lead">${data.sanLuongDuKien || 'Chưa có dữ liệu'}</span></p>
                     <p class="h6">Tiêu chuẩn: <span class="lead">${data.tieuChuan || 'Chưa có dữ liệu'}</span></p>
                    <p class="h6">Tình trạng: <span class="lead">${data.tinhTrang ? 'Hoạt động' : 'Không hoạt động'}</span></p>

                   
                </div>
            </div>
        </div>`;

    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    if (popup == true) {
        infoWindow.open(map);
    }
    else {
        infoWindow.close(map);
    }

}


var pointArray = [];
var pointArrayNew = [];
var check = false;
function initialize(dotNetHelper) {
    const styledMapType = new google.maps.StyledMapType(
        [
            { elementType: "geometry", stylers: [{ color: "#ebe3cd" }] },
            { elementType: "labels.text.fill", stylers: [{ color: "#523735" }] },
            { elementType: "labels.text.stroke", stylers: [{ color: "#f5f1e6" }] },
            {
                featureType: "administrative",
                elementType: "geometry.stroke",
                stylers: [{ color: "#c9b2a6" }],
            },
            {
                featureType: "administrative.land_parcel",
                elementType: "geometry.stroke",
                stylers: [{ color: "#dcd2be" }],
            },
            {
                featureType: "administrative.land_parcel",
                elementType: "labels.text.fill",
                stylers: [{ color: "#ae9e90" }],
            },
            {
                featureType: "landscape.natural",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "poi",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "poi",
                elementType: "labels.text.fill",
                stylers: [{ color: "#93817c" }],
            },
            {
                featureType: "poi.park",
                elementType: "geometry.fill",
                stylers: [{ color: "#a5b076" }],
            },
            {
                featureType: "poi.park",
                elementType: "labels.text.fill",
                stylers: [{ color: "#447530" }],
            },
            {
                featureType: "road",
                elementType: "geometry",
                stylers: [{ color: "#f5f1e6" }],
            },
            {
                featureType: "road.arterial",
                elementType: "geometry",
                stylers: [{ color: "#fdfcf8" }],
            },
            {
                featureType: "road.highway",
                elementType: "geometry",
                stylers: [{ color: "#f8c967" }],
            },
            {
                featureType: "road.highway",
                elementType: "geometry.stroke",
                stylers: [{ color: "#e9bc62" }],
            },
            {
                featureType: "road.highway.controlled_access",
                elementType: "geometry",
                stylers: [{ color: "#e98d58" }],
            },
            {
                featureType: "road.highway.controlled_access",
                elementType: "geometry.stroke",
                stylers: [{ color: "#db8555" }],
            },
            {
                featureType: "road.local",
                elementType: "labels.text.fill",
                stylers: [{ color: "#806b63" }],
            },
            {
                featureType: "transit.line",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "transit.line",
                elementType: "labels.text.fill",
                stylers: [{ color: "#8f7d77" }],
            },
            {
                featureType: "transit.line",
                elementType: "labels.text.stroke",
                stylers: [{ color: "#ebe3cd" }],
            },
            {
                featureType: "transit.station",
                elementType: "geometry",
                stylers: [{ color: "#dfd2ae" }],
            },
            {
                featureType: "water",
                elementType: "geometry.fill",
                stylers: [{ color: "#b9d3c2" }],
            },
            {
                featureType: "water",
                elementType: "labels.text.fill",
                stylers: [{ color: "#92998d" }],
            },
        ],
        { name: "Styled Map" }
    );
    var valueLatLong = document.getElementById("value_latlong").value;

    if (valueLatLong != null && valueLatLong !== "" && valueLatLong) {

        ar = JSON.parse(valueLatLong);
        if (Array.isArray(ar)) {
            pointArray = ar;
        }
        map = new google.maps.Map(document.getElementById("map"), {
            mapId: "8e0a97af9386fef",
            zoom: 10,
            center: center(ar),
            mapTypeControlOptions: {
                mapTypeIds: ["roadmap", "satellite", "hybrid", "terrain", "styled_map"],
            },
        });


        // Biến lưu trữ Marker hiện tại
        var currentMarker = null;
        // Construct the polygon.
        var polygon = new google.maps.Polygon({
            paths: pointArray,
            strokeColor: "#86efac",
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: "#84cc16",
            fillOpacity: 0.35,
        });
        var isFirstClick = true;
        google.maps.event.addListener(map, 'click', function (event) {
            var clickedPoint = event.latLng;
            // Kiểm tra nếu đã có Marker hiện tại
            if (currentMarker) {
                // Xóa Marker khỏi bản đồ
                //currentMarker.setMap(null);
            }

            // Kiểm tra xem polygon đã được khởi tạo và paths có tồn tại
            if (polygon && polygon.getPath()) {

                polygon.getPath().push(clickedPoint);

                pointArray.push(clickedPoint);

                dotNetHelper.invokeMethodAsync('GetLatLong', JSON.stringify(pointArray));

            }
            if (isFirstClick) {
                var marker = new google.maps.Marker({
                    position: event.latLng,
                    map: map,
                });
                currentMarker = marker;
                isFirstClick = false;
            }


        });
        // Đăng ký sự kiện 'rightclick'
        google.maps.event.addListener(map, 'rightclick', function (event) {

            if (polygon && polygon.getPath()) {
                polygon.getPath().pop();
                pointArray.pop();
                dotNetHelper.invokeMethodAsync('GetLatLong', JSON.stringify(pointArray))
            }
            if (currentMarker) {
                // Xóa Marker khỏi bản đồ
                currentMarker.setMap(null);
                currentMarker = null;
            }
        });
        polygon.setMap(map);
        polygon.addListener("click", showArrays);
        infoWindow = new google.maps.InfoWindow();
        //Associate the styled map with the MapTypeId and set it to display.
        map.mapTypes.set("styled_map", styledMapType);
        map.setMapTypeId("styled_map");
    }
    else {
        map = new google.maps.Map(document.getElementById("map"), {
            zoom: 10,
            center: { lat: 22.359262067226613, lng: 103.92808189564398 },
            mapTypeControlOptions: {
                mapTypeIds: ["roadmap", "satellite", "hybrid", "terrain", "styled_map"],
            },
        });


        // Biến lưu trữ Marker hiện tại
        var currentMarker = null;
        // Construct the polygon.
        var poly = new google.maps.Polygon({

            strokeColor: "#86efac",
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: "#84cc16",
            fillOpacity: 0.35,
        });
        var isFirstClick = true;
        google.maps.event.addListener(map, 'click', function (event) {
            var clickedPoint = event.latLng;
            // Kiểm tra nếu đã có Marker hiện tại
            if (currentMarker) {
                // Xóa Marker khỏi bản đồ
                //currentMarker.setMap(null);
            }
            // Kiểm tra xem polygon đã được khởi tạo và paths có tồn tại
            console.log(poly, poly.getPath())
            if (poly && poly.getPath()) {

                poly.getPath().push(clickedPoint);

                pointArrayNew.push(clickedPoint);

                dotNetHelper.invokeMethodAsync('GetLatLong', JSON.stringify(pointArrayNew));

            }
            if (isFirstClick) {
                var marker = new google.maps.Marker({
                    position: event.latLng,
                    map: map,
                });
                currentMarker = marker;
                isFirstClick = false;
            }


        });
        // Đăng ký sự kiện 'rightclick'
        google.maps.event.addListener(map, 'rightclick', function (event) {

            if (poly && poly.getPath()) {
                poly.getPath().pop();
                pointArrayNew.pop();
                dotNetHelper.invokeMethodAsync('GetLatLong', JSON.stringify(pointArrayNew))
            }
            if (currentMarker) {
                // Xóa Marker khỏi bản đồ
                currentMarker.setMap(null);
                currentMarker = null;
            }
        });
        poly.setMap(map);
        poly.addListener("click", showArrays);
        infoWindow = new google.maps.InfoWindow();
        //Associate the styled map with the MapTypeId and set it to display.
        map.mapTypes.set("styled_map", styledMapType);
        map.setMapTypeId("styled_map");
    }


}


function showArrays(event) {
    // Since this polygon has only one path, we can call getPath() to return the
    // MVCArray of LatLngs.
    // @ts-ignore
    var tieude = document.querySelector('input[name=TieuDe]').value
    const polygon = this;
    const vertices = polygon.getPath();
    let contentString =
        /*"<b>Bermuda Triangle polygon</b><br>" +*/
        "<b>Tieu de</b>: " +
        tieude
    //+
    //"," +
    //event.latLng.lng() +
    //"<br>";

    // Iterate over the vertices.
    //for (let i = 0; i < vertices.getLength(); i++) {
    //    const xy = vertices.getAt(i);

    //    contentString +=
    //        "<br>" + "Coordinate " + i + ":<br>" + xy.lat() + "," + xy.lng();
    //}

    // Replace the info window's content and position.
    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    infoWindow.open(map);
}

function center(ar) {
    if (Array.isArray(ar)) {
        let lat = 0;
        let lng = 0;
        ar.forEach(x => {
            lat += x.lat;
            lng += x.lng;
        })
        return {
            lat: lat / ar.length,
            lng: lng / ar.length,
        }
    }

}