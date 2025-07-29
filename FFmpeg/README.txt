FFmpeg 64-bit static Windows build from www.gyan.dev

Version: 2025-07-07-git-d2828ab284-full_build-www.gyan.dev

License: GPL v3

Source Code: https://github.com/FFmpeg/FFmpeg/commit/d2828ab284

External Assets
frei0r plugins:   https://www.gyan.dev/ffmpeg/builds/ffmpeg-frei0r-plugins
lensfun database: https://www.gyan.dev/ffmpeg/builds/ffmpeg-lensfun-db

git-full build configuration: 

ARCH                      x86 (generic)
big-endian                no
runtime cpu detection     yes
standalone assembly       yes
x86 assembler             nasm
MMX enabled               yes
MMXEXT enabled            yes
3DNow! enabled            yes
3DNow! extended enabled   yes
SSE enabled               yes
SSSE3 enabled             yes
AESNI enabled             yes
AVX enabled               yes
AVX2 enabled              yes
AVX-512 enabled           yes
AVX-512ICL enabled        yes
XOP enabled               yes
FMA3 enabled              yes
FMA4 enabled              yes
i686 features enabled     yes
CMOV is fast              yes
EBX available             yes
EBP available             yes
debug symbols             yes
strip symbols             yes
optimize for size         no
optimizations             yes
static                    yes
shared                    no
network support           yes
threading support         pthreads
safe bitstream reader     yes
texi2html enabled         no
perl enabled              yes
pod2man enabled           yes
makeinfo enabled          yes
makeinfo supports HTML    yes
xmllint enabled           yes

External libraries:
avisynth                libgsm                  libssh
bzlib                   libharfbuzz             libsvtav1
chromaprint             libilbc                 libtheora
frei0r                  libjxl                  libtwolame
gmp                     liblc3                  libuavs3d
gnutls                  liblensfun              libvidstab
iconv                   libmodplug              libvmaf
ladspa                  libmp3lame              libvo_amrwbenc
lcms2                   libmysofa               libvorbis
libaom                  liboapv                 libvpx
libaribb24              libopencore_amrnb       libvvenc
libaribcaption          libopencore_amrwb       libwebp
libass                  libopenjpeg             libx264
libbluray               libopenmpt              libx265
libbs2b                 libopus                 libxavs2
libcaca                 libplacebo              libxevd
libcdio                 libqrencode             libxeve
libcodec2               libquirc                libxml2
libdav1d                librav1e                libxvid
libdavs2                librist                 libzimg
libdvdnav               librubberband           libzmq
libdvdread              libshaderc              libzvbi
libflite                libshine                lzma
libfontconfig           libsnappy               mediafoundation
libfreetype             libsoxr                 openal
libfribidi              libspeex                sdl2
libgme                  libsrt                  zlib

External libraries providing hardware acceleration:
amf                     d3d12va                 nvdec
cuda                    dxva2                   nvenc
cuda_llvm               ffnvcodec               opencl
cuvid                   libmfx                  vaapi
d3d11va                 libvpl                  vulkan

Libraries:
avcodec                 avformat                swscale
avdevice                avutil
avfilter                swresample

Programs:
ffmpeg                  ffplay                  ffprobe

Enabled decoders:
aac                     g2m                     pcm_u8
aac_fixed               g723_1                  pcm_vidc
aac_latm                g728                    pcx
aasc                    g729                    pdv
ac3                     gdv                     pfm
ac3_fixed               gem                     pgm
acelp_kelvin            gif                     pgmyuv
adpcm_4xm               gremlin_dpcm            pgssub
adpcm_adx               gsm                     pgx
adpcm_afc               gsm_ms                  phm
adpcm_agm               h261                    photocd
adpcm_aica              h263                    pictor
adpcm_argo              h263i                   pixlet
adpcm_ct                h263p                   pjs
adpcm_dtk               h264                    png
adpcm_ea                h264_amf                ppm
adpcm_ea_maxis_xa       h264_cuvid              prores
adpcm_ea_r1             h264_qsv                prosumer
adpcm_ea_r2             hap                     psd
adpcm_ea_r3             hca                     ptx
adpcm_ea_xas            hcom                    qcelp
adpcm_g722              hdr                     qdm2
adpcm_g726              hevc                    qdmc
adpcm_g726le            hevc_amf                qdraw
adpcm_ima_acorn         hevc_cuvid              qoa
adpcm_ima_alp           hevc_qsv                qoi
adpcm_ima_amv           hnm4_video              qpeg
adpcm_ima_apc           hq_hqa                  qtrle
adpcm_ima_apm           hqx                     r10k
adpcm_ima_cunning       huffyuv                 r210
adpcm_ima_dat4          hymt                    ra_144
adpcm_ima_dk3           iac                     ra_288
adpcm_ima_dk4           idcin                   ralf
adpcm_ima_ea_eacs       idf                     rasc
adpcm_ima_ea_sead       iff_ilbm                rawvideo
adpcm_ima_iss           ilbc                    realtext
adpcm_ima_moflex        imc                     rka
adpcm_ima_mtf           imm4                    rl2
adpcm_ima_oki           imm5                    roq
adpcm_ima_qt            indeo2                  roq_dpcm
adpcm_ima_rad           indeo3                  rpza
adpcm_ima_smjpeg        indeo4                  rscc
adpcm_ima_ssi           indeo5                  rtv1
adpcm_ima_wav           interplay_acm           rv10
adpcm_ima_ws            interplay_dpcm          rv20
adpcm_ima_xbox          interplay_video         rv30
adpcm_ms                ipu                     rv40
adpcm_mtaf              jacosub                 rv60
adpcm_psx               jpeg2000                s302m
adpcm_sanyo             jpegls                  sami
adpcm_sbpro_2           jv                      sanm
adpcm_sbpro_3           kgv1                    sbc
adpcm_sbpro_4           kmvc                    scpr
adpcm_swf               lagarith                screenpresso
adpcm_thp               lead                    sdx2_dpcm
adpcm_thp_le            libaom_av1              sga
adpcm_vima              libaribb24              sgi
adpcm_xa                libaribcaption          sgirle
adpcm_xmd               libcodec2               sheervideo
adpcm_yamaha            libdav1d                shorten
adpcm_zork              libdavs2                simbiosis_imx
agm                     libgsm                  sipr
aic                     libgsm_ms               siren
alac                    libilbc                 smackaud
alias_pix               libjxl                  smacker
als                     libjxl_anim             smc
amrnb                   liblc3                  smvjpeg
amrwb                   libopencore_amrnb       snow
amv                     libopencore_amrwb       sol_dpcm
anm                     libopus                 sonic
ansi                    libspeex                sp5x
anull                   libuavs3d               speedhq
apac                    libvorbis               speex
ape                     libvpx_vp8              srgc
apng                    libvpx_vp9              srt
aptx                    libxevd                 ssa
aptx_hd                 libzvbi_teletext        stl
apv                     loco                    subrip
arbc                    lscr                    subviewer
argo                    m101                    subviewer1
ass                     mace3                   sunrast
asv1                    mace6                   svq1
asv2                    magicyuv                svq3
atrac1                  mdec                    tak
atrac3                  media100                targa
atrac3al                metasound               targa_y216
atrac3p                 microdvd                tdsc
atrac3pal               mimic                   text
atrac9                  misc4                   theora
aura                    mjpeg                   thp
aura2                   mjpeg_cuvid             tiertexseqvideo
av1                     mjpeg_qsv               tiff
av1_amf                 mjpegb                  tmv
av1_cuvid               mlp                     truehd
av1_qsv                 mmvideo                 truemotion1
avrn                    mobiclip                truemotion2
avrp                    motionpixels            truemotion2rt
avs                     movtext                 truespeech
avui                    mp1                     tscc
bethsoftvid             mp1float                tscc2
bfi                     mp2                     tta
bink                    mp2float                twinvq
binkaudio_dct           mp3                     txd
binkaudio_rdft          mp3adu                  ulti
bintext                 mp3adufloat             utvideo
bitpacked               mp3float                v210
bmp                     mp3on4                  v210x
bmv_audio               mp3on4float             v308
bmv_video               mpc7                    v408
bonk                    mpc8                    v410
brender_pix             mpeg1_cuvid             vb
c93                     mpeg1video              vble
cavs                    mpeg2_cuvid             vbn
cbd2_dpcm               mpeg2_qsv               vc1
ccaption                mpeg2video              vc1_cuvid
cdgraphics              mpeg4                   vc1_qsv
cdtoons                 mpeg4_cuvid             vc1image
cdxl                    mpegvideo               vcr1
cfhd                    mpl2                    vmdaudio
cinepak                 msa1                    vmdvideo
clearvideo              mscc                    vmix
cljr                    msmpeg4v1               vmnc
cllc                    msmpeg4v2               vnull
comfortnoise            msmpeg4v3               vorbis
cook                    msnsiren                vp3
cpia                    msp2                    vp4
cri                     msrle                   vp5
cscd                    mss1                    vp6
cyuv                    mss2                    vp6a
dca                     msvideo1                vp6f
dds                     mszh                    vp7
derf_dpcm               mts2                    vp8
dfa                     mv30                    vp8_cuvid
dfpwm                   mvc1                    vp8_qsv
dirac                   mvc2                    vp9
dnxhd                   mvdv                    vp9_amf
dolby_e                 mvha                    vp9_cuvid
dpx                     mwsc                    vp9_qsv
dsd_lsbf                mxpeg                   vplayer
dsd_lsbf_planar         nellymoser              vqa
dsd_msbf                notchlc                 vqc
dsd_msbf_planar         nuv                     vvc
dsicinaudio             on2avc                  vvc_qsv
dsicinvideo             opus                    wady_dpcm
dss_sp                  osq                     wavarc
dst                     paf_audio               wavpack
dvaudio                 paf_video               wbmp
dvbsub                  pam                     wcmv
dvdsub                  pbm                     webp
dvvideo                 pcm_alaw                webvtt
dxa                     pcm_bluray              wmalossless
dxtory                  pcm_dvd                 wmapro
dxv                     pcm_f16le               wmav1
eac3                    pcm_f24le               wmav2
eacmv                   pcm_f32be               wmavoice
eamad                   pcm_f32le               wmv1
eatgq                   pcm_f64be               wmv2
eatgv                   pcm_f64le               wmv3
eatqi                   pcm_lxf                 wmv3image
eightbps                pcm_mulaw               wnv1
eightsvx_exp            pcm_s16be               wrapped_avframe
eightsvx_fib            pcm_s16be_planar        ws_snd1
escape124               pcm_s16le               xan_dpcm
escape130               pcm_s16le_planar        xan_wc3
evrc                    pcm_s24be               xan_wc4
exr                     pcm_s24daud             xbin
fastaudio               pcm_s24le               xbm
ffv1                    pcm_s24le_planar        xface
ffvhuff                 pcm_s32be               xl
ffwavesynth             pcm_s32le               xma1
fic                     pcm_s32le_planar        xma2
fits                    pcm_s64be               xpm
flac                    pcm_s64le               xsub
flashsv                 pcm_s8                  xwd
flashsv2                pcm_s8_planar           y41p
flic                    pcm_sga                 ylc
flv                     pcm_u16be               yop
fmvc                    pcm_u16le               yuv4
fourxm                  pcm_u24be               zero12v
fraps                   pcm_u24le               zerocodec
frwu                    pcm_u32be               zlib
ftr                     pcm_u32le               zmbv

Enabled encoders:
a64multi                hevc_qsv                pcm_s64be
a64multi5               hevc_vaapi              pcm_s64le
aac                     hevc_vulkan             pcm_s8
aac_mf                  huffyuv                 pcm_s8_planar
ac3                     jpeg2000                pcm_u16be
ac3_fixed               jpegls                  pcm_u16le
ac3_mf                  libaom_av1              pcm_u24be
adpcm_adx               libcodec2               pcm_u24le
adpcm_argo              libgsm                  pcm_u32be
adpcm_g722              libgsm_ms               pcm_u32le
adpcm_g726              libilbc                 pcm_u8
adpcm_g726le            libjxl                  pcm_vidc
adpcm_ima_alp           libjxl_anim             pcx
adpcm_ima_amv           liblc3                  pfm
adpcm_ima_apm           libmp3lame              pgm
adpcm_ima_qt            liboapv                 pgmyuv
adpcm_ima_ssi           libopencore_amrnb       phm
adpcm_ima_wav           libopenjpeg             png
adpcm_ima_ws            libopus                 ppm
adpcm_ms                librav1e                prores
adpcm_swf               libshine                prores_aw
adpcm_yamaha            libspeex                prores_ks
alac                    libsvtav1               qoi
alias_pix               libtheora               qtrle
amv                     libtwolame              r10k
anull                   libvo_amrwbenc          r210
apng                    libvorbis               ra_144
aptx                    libvpx_vp8              rawvideo
aptx_hd                 libvpx_vp9              roq
ass                     libvvenc                roq_dpcm
asv1                    libwebp                 rpza
asv2                    libwebp_anim            rv10
av1_amf                 libx264                 rv20
av1_mf                  libx264rgb              s302m
av1_nvenc               libx265                 sbc
av1_qsv                 libxavs2                sgi
av1_vaapi               libxeve                 smc
avrp                    libxvid                 snow
avui                    ljpeg                   speedhq
bitpacked               magicyuv                srt
bmp                     mjpeg                   ssa
cfhd                    mjpeg_qsv               subrip
cinepak                 mjpeg_vaapi             sunrast
cljr                    mlp                     svq1
comfortnoise            movtext                 targa
dca                     mp2                     text
dfpwm                   mp2fixed                tiff
dnxhd                   mp3_mf                  truehd
dpx                     mpeg1video              tta
dvbsub                  mpeg2_qsv               ttml
dvdsub                  mpeg2_vaapi             utvideo
dvvideo                 mpeg2video              v210
dxv                     mpeg4                   v308
eac3                    msmpeg4v2               v408
exr                     msmpeg4v3               v410
ffv1                    msrle                   vbn
ffv1_vulkan             msvideo1                vc2
ffvhuff                 nellymoser              vnull
fits                    opus                    vorbis
flac                    pam                     vp8_vaapi
flashsv                 pbm                     vp9_qsv
flashsv2                pcm_alaw                vp9_vaapi
flv                     pcm_bluray              wavpack
g723_1                  pcm_dvd                 wbmp
gif                     pcm_f32be               webvtt
h261                    pcm_f32le               wmav1
h263                    pcm_f64be               wmav2
h263p                   pcm_f64le               wmv1
h264_amf                pcm_mulaw               wmv2
h264_mf                 pcm_s16be               wrapped_avframe
h264_nvenc              pcm_s16be_planar        xbm
h264_qsv                pcm_s16le               xface
h264_vaapi              pcm_s16le_planar        xsub
h264_vulkan             pcm_s24be               xwd
hap                     pcm_s24daud             y41p
hdr                     pcm_s24le               yuv4
hevc_amf                pcm_s24le_planar        zlib
hevc_d3d12va            pcm_s32be               zmbv
hevc_mf                 pcm_s32le
hevc_nvenc              pcm_s32le_planar

Enabled hwaccels:
av1_d3d11va             hevc_dxva2              vc1_nvdec
av1_d3d11va2            hevc_nvdec              vc1_vaapi
av1_d3d12va             hevc_vaapi              vp8_nvdec
av1_dxva2               hevc_vulkan             vp8_vaapi
av1_nvdec               mjpeg_nvdec             vp9_d3d11va
av1_vaapi               mjpeg_vaapi             vp9_d3d11va2
av1_vulkan              mpeg1_nvdec             vp9_d3d12va
ffv1_vulkan             mpeg2_d3d11va           vp9_dxva2
h263_vaapi              mpeg2_d3d11va2          vp9_nvdec
h264_d3d11va            mpeg2_d3d12va           vp9_vaapi
h264_d3d11va2           mpeg2_dxva2             vvc_vaapi
h264_d3d12va            mpeg2_nvdec             wmv3_d3d11va
h264_dxva2              mpeg2_vaapi             wmv3_d3d11va2
h264_nvdec              mpeg4_nvdec             wmv3_d3d12va
h264_vaapi              mpeg4_vaapi             wmv3_dxva2
h264_vulkan             vc1_d3d11va             wmv3_nvdec
hevc_d3d11va            vc1_d3d11va2            wmv3_vaapi
hevc_d3d11va2           vc1_d3d12va
hevc_d3d12va            vc1_dxva2

Enabled parsers:
aac                     dvd_nav                 mpeg4video
aac_latm                dvdsub                  mpegaudio
ac3                     evc                     mpegvideo
adx                     ffv1                    opus
amr                     flac                    png
apv                     ftr                     pnm
av1                     g723_1                  qoi
avs2                    g729                    rv34
avs3                    gif                     sbc
bmp                     gsm                     sipr
cavsvideo               h261                    tak
cook                    h263                    vc1
cri                     h264                    vorbis
dca                     hdr                     vp3
dirac                   hevc                    vp8
dnxhd                   ipu                     vp9
dnxuc                   jpeg2000                vvc
dolby_e                 jpegxl                  webp
dpx                     misc4                   xbm
dvaudio                 mjpeg                   xma
dvbsub                  mlp                     xwd

Enabled demuxers:
aa                      ico                     pcm_f64be
aac                     idcin                   pcm_f64le
aax                     idf                     pcm_mulaw
ac3                     iff                     pcm_s16be
ac4                     ifv                     pcm_s16le
ace                     ilbc                    pcm_s24be
acm                     image2                  pcm_s24le
act                     image2_alias_pix        pcm_s32be
adf                     image2_brender_pix      pcm_s32le
adp                     image2pipe              pcm_s8
ads                     image_bmp_pipe          pcm_u16be
adx                     image_cri_pipe          pcm_u16le
aea                     image_dds_pipe          pcm_u24be
afc                     image_dpx_pipe          pcm_u24le
aiff                    image_exr_pipe          pcm_u32be
aix                     image_gem_pipe          pcm_u32le
alp                     image_gif_pipe          pcm_u8
amr                     image_hdr_pipe          pcm_vidc
amrnb                   image_j2k_pipe          pdv
amrwb                   image_jpeg_pipe         pjs
anm                     image_jpegls_pipe       pmp
apac                    image_jpegxl_pipe       pp_bnk
apc                     image_pam_pipe          pva
ape                     image_pbm_pipe          pvf
apm                     image_pcx_pipe          qcp
apng                    image_pfm_pipe          qoa
aptx                    image_pgm_pipe          r3d
aptx_hd                 image_pgmyuv_pipe       rawvideo
apv                     image_pgx_pipe          rcwt
aqtitle                 image_phm_pipe          realtext
argo_asf                image_photocd_pipe      redspark
argo_brp                image_pictor_pipe       rka
argo_cvg                image_png_pipe          rl2
asf                     image_ppm_pipe          rm
asf_o                   image_psd_pipe          roq
ass                     image_qdraw_pipe        rpl
ast                     image_qoi_pipe          rsd
au                      image_sgi_pipe          rso
av1                     image_sunrast_pipe      rtp
avi                     image_svg_pipe          rtsp
avisynth                image_tiff_pipe         s337m
avr                     image_vbn_pipe          sami
avs                     image_webp_pipe         sap
avs2                    image_xbm_pipe          sbc
avs3                    image_xpm_pipe          sbg
bethsoftvid             image_xwd_pipe          scc
bfi                     imf                     scd
bfstm                   ingenient               sdns
bink                    ipmovie                 sdp
binka                   ipu                     sdr2
bintext                 ircam                   sds
bit                     iss                     sdx
bitpacked               iv8                     segafilm
bmv                     ivf                     ser
boa                     ivr                     sga
bonk                    jacosub                 shorten
brstm                   jpegxl_anim             siff
c93                     jv                      simbiosis_imx
caf                     kux                     sln
cavsvideo               kvag                    smacker
cdg                     laf                     smjpeg
cdxl                    lc3                     smush
cine                    libgme                  sol
codec2                  libmodplug              sox
codec2raw               libopenmpt              spdif
concat                  live_flv                srt
dash                    lmlm4                   stl
data                    loas                    str
daud                    lrc                     subviewer
dcstr                   luodat                  subviewer1
derf                    lvf                     sup
dfa                     lxf                     svag
dfpwm                   m4v                     svs
dhav                    matroska                swf
dirac                   mca                     tak
dnxhd                   mcc                     tedcaptions
dsf                     mgsts                   thp
dsicin                  microdvd                threedostr
dss                     mjpeg                   tiertexseq
dts                     mjpeg_2000              tmv
dtshd                   mlp                     truehd
dv                      mlv                     tta
dvbsub                  mm                      tty
dvbtxt                  mmf                     txd
dvdvideo                mods                    ty
dxa                     moflex                  usm
ea                      mov                     v210
ea_cdata                mp3                     v210x
eac3                    mpc                     vag
epaf                    mpc8                    vc1
evc                     mpegps                  vc1t
ffmetadata              mpegts                  vividas
filmstrip               mpegtsraw               vivo
fits                    mpegvideo               vmd
flac                    mpjpeg                  vobsub
flic                    mpl2                    voc
flv                     mpsub                   vpk
fourxm                  msf                     vplayer
frm                     msnwc_tcp               vqf
fsb                     msp                     vvc
fwse                    mtaf                    w64
g722                    mtv                     wady
g723_1                  musx                    wav
g726                    mv                      wavarc
g726le                  mvi                     wc3
g728                    mxf                     webm_dash_manifest
g729                    mxg                     webvtt
gdv                     nc                      wsaud
genh                    nistsphere              wsd
gif                     nsp                     wsvqa
gsm                     nsv                     wtv
gxf                     nut                     wv
h261                    nuv                     wve
h263                    obu                     xa
h264                    ogg                     xbin
hca                     oma                     xmd
hcom                    osq                     xmv
hevc                    paf                     xvag
hls                     pcm_alaw                xwma
hnm                     pcm_f32be               yop
iamf                    pcm_f32le               yuv4mpegpipe

Enabled muxers:
a64                     h261                    pcm_s16le
ac3                     h263                    pcm_s24be
ac4                     h264                    pcm_s24le
adts                    hash                    pcm_s32be
adx                     hds                     pcm_s32le
aea                     hevc                    pcm_s8
aiff                    hls                     pcm_u16be
alp                     iamf                    pcm_u16le
amr                     ico                     pcm_u24be
amv                     ilbc                    pcm_u24le
apm                     image2                  pcm_u32be
apng                    image2pipe              pcm_u32le
aptx                    ipod                    pcm_u8
aptx_hd                 ircam                   pcm_vidc
apv                     ismv                    psp
argo_asf                ivf                     rawvideo
argo_cvg                jacosub                 rcwt
asf                     kvag                    rm
asf_stream              latm                    roq
ass                     lc3                     rso
ast                     lrc                     rtp
au                      m4v                     rtp_mpegts
avi                     matroska                rtsp
avif                    matroska_audio          sap
avm2                    md5                     sbc
avs2                    microdvd                scc
avs3                    mjpeg                   segafilm
bit                     mkvtimestamp_v2         segment
caf                     mlp                     smjpeg
cavsvideo               mmf                     smoothstreaming
chromaprint             mov                     sox
codec2                  mp2                     spdif
codec2raw               mp3                     spx
crc                     mp4                     srt
dash                    mpeg1system             stream_segment
data                    mpeg1vcd                streamhash
daud                    mpeg1video              sup
dfpwm                   mpeg2dvd                swf
dirac                   mpeg2svcd               tee
dnxhd                   mpeg2video              tg2
dts                     mpeg2vob                tgp
dv                      mpegts                  truehd
eac3                    mpjpeg                  tta
evc                     mxf                     ttml
f4v                     mxf_d10                 uncodedframecrc
ffmetadata              mxf_opatom              vc1
fifo                    null                    vc1t
filmstrip               nut                     voc
fits                    obu                     vvc
flac                    oga                     w64
flv                     ogg                     wav
framecrc                ogv                     webm
framehash               oma                     webm_chunk
framemd5                opus                    webm_dash_manifest
g722                    pcm_alaw                webp
g723_1                  pcm_f32be               webvtt
g726                    pcm_f32le               wsaud
g726le                  pcm_f64be               wtv
gif                     pcm_f64le               wv
gsm                     pcm_mulaw               yuv4mpegpipe
gxf                     pcm_s16be

Enabled protocols:
async                   http                    rtmp
bluray                  httpproxy               rtmpe
cache                   https                   rtmps
concat                  icecast                 rtmpt
concatf                 ipfs_gateway            rtmpte
crypto                  ipns_gateway            rtmpts
data                    librist                 rtp
fd                      libsrt                  srtp
ffrtmpcrypt             libssh                  subfile
ffrtmphttp              libzmq                  tcp
file                    md5                     tee
ftp                     mmsh                    tls
gopher                  mmst                    udp
gophers                 pipe                    udplite
hls                     prompeg

Enabled filters:
a3dscope                deblock                 perlin
aap                     decimate                perms
abench                  deconvolve              perspective
abitscope               dedot                   phase
acompressor             deesser                 photosensitivity
acontrast               deflate                 pixdesctest
acopy                   deflicker               pixelize
acrossfade              deinterlace_qsv         pixscope
acrossover              deinterlace_vaapi       pp7
acrusher                dejudder                premultiply
acue                    delogo                  prewitt
addroi                  denoise_vaapi           prewitt_opencl
adeclick                deshake                 procamp_vaapi
adeclip                 deshake_opencl          program_opencl
adecorrelate            despill                 pseudocolor
adelay                  detelecine              psnr
adenorm                 dialoguenhance          pullup
aderivative             dilation                qp
adrawgraph              dilation_opencl         qrencode
adrc                    displace                qrencodesrc
adynamicequalizer       doubleweave             quirc
adynamicsmooth          drawbox                 random
aecho                   drawbox_vaapi           readeia608
aemphasis               drawgraph               readvitc
aeval                   drawgrid                realtime
aevalsrc                drawtext                remap
aexciter                drmeter                 remap_opencl
afade                   dynaudnorm              removegrain
afdelaysrc              earwax                  removelogo
afftdn                  ebur128                 repeatfields
afftfilt                edgedetect              replaygain
afir                    elbg                    reverse
afireqsrc               entropy                 rgbashift
afirsrc                 epx                     rgbtestsrc
aformat                 eq                      roberts
afreqshift              equalizer               roberts_opencl
afwtdn                  erosion                 rotate
agate                   erosion_opencl          rubberband
agraphmonitor           estdif                  sab
ahistogram              exposure                scale
aiir                    extractplanes           scale2ref
aintegral               extrastereo             scale_cuda
ainterleave             fade                    scale_qsv
alatency                feedback                scale_vaapi
alimiter                fftdnoiz                scale_vulkan
allpass                 fftfilt                 scdet
allrgb                  field                   scdet_vulkan
allyuv                  fieldhint               scharr
aloop                   fieldmatch              scroll
alphaextract            fieldorder              segment
alphamerge              fillborders             select
amerge                  find_rect               selectivecolor
ametadata               firequalizer            sendcmd
amix                    flanger                 separatefields
amovie                  flip_vulkan             setdar
amplify                 flite                   setfield
amultiply               floodfill               setparams
anequalizer             format                  setpts
anlmdn                  fps                     setrange
anlmf                   framepack               setsar
anlms                   Leonardate               settb
anoisesrc               framestep               sharpness_vaapi
anull                   freezedetect            shear
anullsink               freezeframes            showcqt
anullsrc                frei0r                  showcwt
apad                    frei0r_src              showfreqs
aperms                  fspp                    showinfo
aphasemeter             fsync                   showpalette
aphaser                 gblur                   showspatial
aphaseshift             gblur_vulkan            showspectrum
apsnr                   geq                     showspectrumpic
apsyclip                gradfun                 showvolume
apulsator               gradients               showwaves
arealtime               graphmonitor            showwavespic
aresample               grayworld               shuffleframes
areverse                greyedge                shufflepixels
arls                    guided                  shuffleplanes
arnndn                  haas                    sidechaincompress
asdr                    haldclut                sidechaingate
asegment                haldclutsrc             sidedata
aselect                 hdcd                    sierpinski
asendcmd                headphone               signalstats
asetnsamples            hflip                   signature
asetpts                 hflip_vulkan            silencedetect
asetrate                highpass                silenceremove
asettb                  highshelf               sinc
ashowinfo               hilbert                 sine
asidedata               histeq                  siti
asisdr                  histogram               smartblur
asoftclip               hqdn3d                  smptebars
aspectralstats          hqx                     smptehdbars
asplit                  hstack                  sobel
ass                     hstack_qsv              sobel_opencl
astats                  hstack_vaapi            sofalizer
astreamselect           hsvhold                 spectrumsynth
asubboost               hsvkey                  speechnorm
asubcut                 hue                     split
asupercut               huesaturation           spp
asuperpass              hwdownload              sr_amf
asuperstop              hwmap                   ssim
atadenoise              hwupload                ssim360
atempo                  hwupload_cuda           stereo3d
atilt                   hysteresis              stereotools
atrim                   iccdetect               stereowiden
avectorscope            iccgen                  streamselect
avgblur                 identity                subtitles
avgblur_opencl          idet                    super2xsai
avgblur_vulkan          il                      superequalizer
avsynctest              inflate                 surround
axcorrelate             interlace               swaprect
azmq                    interlace_vulkan        swapuv
backgroundkey           interleave              tblend
bandpass                join                    telecine
bandreject              kerndeint               testsrc
bass                    kirsch                  testsrc2
bbox                    ladspa                  thistogram
bench                   lagfun                  threshold
bilateral               latency                 thumbnail
bilateral_cuda          lenscorrection          thumbnail_cuda
biquad                  lensfun                 tile
bitplanenoise           libplacebo              tiltandshift
blackdetect             libvmaf                 tiltshelf
blackdetect_vulkan      life                    tinterlace
blackframe              limitdiff               tlut2
blend                   limiter                 tmedian
blend_vulkan            loop                    tmidequalizer
blockdetect             loudnorm                tmix
blurdetect              lowpass                 tonemap
bm3d                    lowshelf                tonemap_opencl
boxblur                 lumakey                 tonemap_vaapi
boxblur_opencl          lut                     tpad
bs2b                    lut1d                   transpose
bwdif                   lut2                    transpose_opencl
bwdif_cuda              lut3d                   transpose_vaapi
bwdif_vulkan            lutrgb                  transpose_vulkan
cas                     lutyuv                  treble
ccrepack                mandelbrot              tremolo
cellauto                maskedclamp             trim
channelmap              maskedmax               unpremultiply
channelsplit            maskedmerge             unsharp
chorus                  maskedmin               unsharp_opencl
chromaber_vulkan        maskedthreshold         untile
chromahold              maskfun                 uspp
chromakey               mcdeint                 v360
chromakey_cuda          mcompand                vaguedenoiser
chromanr                median                  varblur
chromashift             mergeplanes             vectorscope
ciescope                mestimate               vflip
codecview               metadata                vflip_vulkan
color                   midequalizer            vfrdet
color_vulkan            minterpolate            vibrance
colorbalance            mix                     vibrato
colorchannelmixer       monochrome              vidstabdetect
colorchart              morpho                  vidstabtransform
colorcontrast           movie                   vif
colorcorrect            mpdecimate              vignette
colorhold               mptestsrc               virtualbass
colorize                msad                    vmafmotion
colorkey                multiply                volume
colorkey_opencl         negate                  volumedetect
colorlevels             nlmeans                 vpp_amf
colormap                nlmeans_opencl          vpp_qsv
colormatrix             nlmeans_vulkan          vstack
colorspace              nnedi                   vstack_qsv
colorspace_cuda         noformat                vstack_vaapi
colorspectrum           noise                   w3fdif
colortemperature        normalize               waveform
compand                 null                    weave
compensationdelay       nullsink                xbr
concat                  nullsrc                 xcorrelate
convolution             openclsrc               xfade
convolution_opencl      oscilloscope            xfade_opencl
convolve                overlay                 xfade_vulkan
copy                    overlay_cuda            xmedian
corr                    overlay_opencl          xpsnr
cover_rect              overlay_qsv             xstack
crop                    overlay_vaapi           xstack_qsv
cropdetect              overlay_vulkan          xstack_vaapi
crossfeed               owdenoise               yadif
crystalizer             pad                     yadif_cuda
cue                     pad_cuda                yaepblur
curves                  pad_opencl              yuvtestsrc
datascope               pad_vaapi               zmq
dblur                   pal100bars              zoneplate
dcshift                 pal75bars               zoompan
dctdnoiz                palettegen              zscale
ddagrab                 paletteuse
deband                  pan

Enabled bsfs:
aac_adtstoasc           h264_mp4toannexb        pgs_frame_merge
apv_metadata            h264_redundant_pps      prores_metadata
av1_frame_merge         hapqa_extract           remove_extradata
av1_frame_split         hevc_metadata           setts
av1_metadata            hevc_mp4toannexb        showinfo
chomp                   imx_dump_header         text2movsub
dca_core                media100_to_mjpegb      trace_headers
dovi_rpu                mjpeg2jpeg              truehd_core
dts2pts                 mjpega_dump_header      vp9_metadata
dump_extradata          mov2textsub             vp9_raw_reorder
dv_error_marker         mpeg2_metadata          vp9_superframe
eac3_core               mpeg4_unpack_bframes    vp9_superframe_split
evc_frame_merge         noise                   vvc_metadata
extract_extradata       null                    vvc_mp4toannexb
filter_units            opus_metadata
h264_metadata           pcm_rechunk

Enabled indevs:
dshow                   lavfi                   openal
gdigrab                 libcdio                 vfwcap

Enabled outdevs:
caca

git-full external libraries' versions: 

AMF v1.4.36-2-gd7311e3
aom v3.12.1-201-g96bfde38d9
aribb24 v1.0.3-5-g5e9be27
aribcaption 1.1.1
AviSynthPlus v3.7.5-22-g66f0d678
bs2b 3.1.0
chromaprint 1.5.1
codec2 1.2.0-106-g96e8a19c
dav1d 1.5.1-15-gc3f3a7e
davs2 1.7-1-gb41cf11
dvdnav 6.1.1-23-g9831fe0
dvdread 6.1.3-15-g786e735
ffnvcodec n13.0.19.0-1-gf2fb9b3
flite v2.2-55-g6c9f20d
freetype VER-2-13-3
frei0r v2.3.3-15-gb47c180
fribidi v1.0.16-2-gb28f43b
gsm 1.0.22
harfbuzz 11.2.1-120-g50debc37
ladspa-sdk 1.17
lame 3.100
lc3 1.1.3
lcms2 2.16
lensfun v0.3.95-1689-g32fa8b92
libass 0.17.4-9-g26217e0
libcdio-paranoia 10.2
libgme 0.6.4
libilbc v3.0.4-346-g6adb26d4a4
libjxl v0.11-snapshot-322-g81247d5c
libopencore-amrnb 0.1.6
libopencore-amrwb 0.1.6
libplacebo v7.351.0-19-g4ff55e0
libsoxr 0.1.3
libssh 0.11.2
libtheora 1.2.0
libwebp v1.5.0-55-gfa6f5649
openal-soft utils-5-gee6d757
openapv v0.1.13.1-44-gad8e6f8
OpenCL-Headers v2025.06.13-1-gb79b358
openmpt libopenmpt-0.6.23-11-g5464f5368
opus v1.5.2-141-gfccfe856
qrencode 4.1.1
quirc 1.2
rav1e p20250624
rist 0.2.12
rubberband v1.8.1
SDL release-2.32.0-61-gcd0cf8b85
shaderc v2025.3-2-gc845638
shine 3.1.1
snappy 1.2.2
speex Speex-1.2.1-51-g0589522
srt v1.5.4-36-g0c570a1
SVT-AV1 v3.0.2-98-g2642c13b
twolame 0.4.0
uavs3d v1.1-47-g1fd0491
VAAPI 2.23.0.
vidstab v1.1.1-16-gd5a313a
vmaf v3.0.0-112-gb9ac69e6
vo-amrwbenc 0.1.3
vorbis v1.3.7-10-g84c02369
VPL 2.15
vpx v1.15.2-92-gae32a476b
vulkan-loader v1.4.321
vvenc v1.13.1-98-g5c2b2cb
x264 v0.165.3222
x265 4.1-189-gcd4f0d6e9
xavs2 1.4
xevd 0.5.0
xeve 0.5.1
xvid v1.3.7
zeromq 4.3.5
zimg release-3.0.5-206-gbde53c0
zvbi v0.2.44

