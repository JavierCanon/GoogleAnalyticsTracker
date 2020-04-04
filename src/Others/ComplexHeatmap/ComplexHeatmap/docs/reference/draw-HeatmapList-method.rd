<!-- Generated by pkgdown: do not edit by hand -->
<!DOCTYPE html>
<html lang="en">
  <head>
  <meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>Draw a list of heatmaps — draw-HeatmapList-method • ComplexHeatmap</title>

<!-- jquery -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
<!-- Bootstrap -->

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha256-916EbMg70RQy9LHiGkXzG8hSg9EdNy97GazNG/aiY1w=" crossorigin="anonymous" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha256-U5ZEeKfGNOja007MMD3YBI0A3OSZOQbeG6z2f2Y0hu8=" crossorigin="anonymous"></script>

<!-- Font Awesome icons -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.7.1/css/all.min.css" integrity="sha256-nAmazAk6vS34Xqo0BSrTb+abbtFlgsFK7NKSi6o7Y78=" crossorigin="anonymous" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.7.1/css/v4-shims.min.css" integrity="sha256-6qHlizsOWFskGlwVOKuns+D1nB6ssZrHQrNj1wGplHc=" crossorigin="anonymous" />

<!-- clipboard.js -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/clipboard.js/2.0.4/clipboard.min.js" integrity="sha256-FiZwavyI2V6+EXO1U+xzLG3IKldpiTFf3153ea9zikQ=" crossorigin="anonymous"></script>

<!-- headroom.js -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/headroom/0.9.4/headroom.min.js" integrity="sha256-DJFC1kqIhelURkuza0AvYal5RxMtpzLjFhsnVIeuk+U=" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/headroom/0.9.4/jQuery.headroom.min.js" integrity="sha256-ZX/yNShbjqsohH1k95liqY9Gd8uOiE1S4vZc+9KQ1K4=" crossorigin="anonymous"></script>

<!-- pkgdown -->
<link href="../pkgdown.css" rel="stylesheet">
<script src="../pkgdown.js"></script>



<meta property="og:title" content="Draw a list of heatmaps — draw-HeatmapList-method" />

<meta property="og:description" content="Draw a list of heatmaps" />
<meta name="twitter:card" content="summary" />



<!-- mathjax -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js" integrity="sha256-nvJJv9wWKEm88qvoQl9ekL2J+k/RWIsaSScxxlsrv8k=" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/config/TeX-AMS-MML_HTMLorMML.js" integrity="sha256-84DKXVJXs0/F8OTMzX4UR909+jtl4G7SPypPavF+GfA=" crossorigin="anonymous"></script>

<!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->



  </head>

  <body>
    <div class="container template-reference-topic">
      <header>
      <div class="navbar navbar-default navbar-fixed-top" role="navigation">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <span class="navbar-brand">
        <a class="navbar-link" href="../index.html">ComplexHeatmap</a>
        <span class="version label label-default" data-toggle="tooltip" data-placement="bottom" title="Released version">2.1.0</span>
      </span>
    </div>

    <div id="navbar" class="navbar-collapse collapse">
      <ul class="nav navbar-nav">
        <li>
  <a href="../index.html">
    <span class="fas fa fas fa-home fa-lg"></span>
     
  </a>
</li>
<li>
  <a href="../reference/index.html">Reference</a>
</li>
<li class="dropdown">
  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
    Articles
     
    <span class="caret"></span>
  </a>
  <ul class="dropdown-menu" role="menu">
    <li>
      <a href="../articles/complex_heatmap.html">UNKNOWN TITLE</a>
    </li>
    <li>
      <a href="../articles/most_probably_asked_questions.html">UNKNOWN TITLE</a>
    </li>
  </ul>
</li>
      </ul>
      
      <ul class="nav navbar-nav navbar-right">
        <li>
  <a href="https://github.com/jokergoo/ComplexHeatmap">
    <span class="fab fa fab fa-github fa-lg"></span>
     
  </a>
</li>
      </ul>
      
    </div><!--/.nav-collapse -->
  </div><!--/.container -->
</div><!--/.navbar -->

      

      </header>

<div class="row">
  <div class="col-md-9 contents">
    <div class="page-header">
    <h1>Draw a list of heatmaps</h1>
    
    <div class="hidden name"><code>draw-HeatmapList-method.rd</code></div>
    </div>

    <div class="ref-description">
    
    <p>Draw a list of heatmaps</p>
    
    </div>

    <pre class="usage"><span class='co'># S4 method for HeatmapList</span>
<span class='fu'><a href='draw-dispatch.rd.html'>draw</a></span>(<span class='no'>object</span>,
    <span class='kw'>newpage</span> <span class='kw'>=</span> <span class='fl'>TRUE</span>,

    <span class='kw'>row_title</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/character.html'>character</a></span>(<span class='fl'>0</span>),
    <span class='kw'>row_title_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"left"</span>, <span class='st'>"right"</span>),
    <span class='kw'>row_title_gp</span> <span class='kw'>=</span> <span class='fu'>gpar</span>(<span class='kw'>fontsize</span> <span class='kw'>=</span> <span class='fl'>14</span>),
    <span class='kw'>column_title</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/character.html'>character</a></span>(<span class='fl'>0</span>),
    <span class='kw'>column_title_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"top"</span>, <span class='st'>"bottom"</span>),
    <span class='kw'>column_title_gp</span> <span class='kw'>=</span> <span class='fu'>gpar</span>(<span class='kw'>fontsize</span> <span class='kw'>=</span> <span class='fl'>14</span>),

    <span class='kw'>heatmap_legend_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"right"</span>, <span class='st'>"left"</span>, <span class='st'>"bottom"</span>, <span class='st'>"top"</span>),
    <span class='kw'>merge_legends</span> <span class='kw'>=</span> <span class='fl'>FALSE</span>,
    <span class='kw'>show_heatmap_legend</span> <span class='kw'>=</span> <span class='fl'>TRUE</span>,
    <span class='kw'>heatmap_legend_list</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/list.html'>list</a></span>(),
    <span class='kw'>annotation_legend_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"right"</span>, <span class='st'>"left"</span>, <span class='st'>"bottom"</span>, <span class='st'>"top"</span>),
    <span class='kw'>show_annotation_legend</span> <span class='kw'>=</span> <span class='fl'>TRUE</span>,
    <span class='kw'>annotation_legend_list</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/list.html'>list</a></span>(),

    <span class='kw'>gap</span> <span class='kw'>=</span> <span class='fu'>unit</span>(<span class='fl'>2</span>, <span class='st'>"mm"</span>),
    <span class='kw'>ht_gap</span> <span class='kw'>=</span> <span class='no'>gap</span>,

    <span class='kw'>main_heatmap</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/which.html'>which</a></span>(<span class='fu'><a href='https://rdrr.io/r/base/lapply.html'>sapply</a></span>(<span class='no'>object</span>@<span class='kw'>ht_list</span>, <span class='no'>inherits</span>, <span class='st'>"Heatmap"</span>))[<span class='fl'>1</span>],
    <span class='kw'>padding</span> <span class='kw'>=</span> <span class='no'>GLOBAL_PADDING</span>,
    <span class='kw'>adjust_annotation_extension</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,

    <span class='kw'>auto_adjust</span> <span class='kw'>=</span> <span class='fl'>TRUE</span>,
    <span class='kw'>row_dend_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"original"</span>, <span class='st'>"left"</span>, <span class='st'>"right"</span>),
    <span class='kw'>row_sub_title_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"original"</span>, <span class='st'>"left"</span>, <span class='st'>"right"</span>),
    <span class='kw'>column_dend_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"original"</span>, <span class='st'>"top"</span>, <span class='st'>"bottom"</span>),
    <span class='kw'>column_sub_title_side</span> <span class='kw'>=</span> <span class='fu'><a href='https://rdrr.io/r/base/c.html'>c</a></span>(<span class='st'>"original"</span>, <span class='st'>"top"</span>, <span class='st'>"bottom"</span>),

    <span class='kw'>row_gap</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>cluster_rows</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>cluster_row_slices</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>clustering_distance_rows</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>clustering_method_rows</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_dend_width</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>show_row_dend</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_dend_reorder</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_dend_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_order</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>km</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>split</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_km</span> <span class='kw'>=</span> <span class='no'>km</span>,
    <span class='kw'>row_km_repeats</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>row_split</span> <span class='kw'>=</span> <span class='no'>split</span>,
    <span class='kw'>height</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_height</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,

    <span class='kw'>column_gap</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>cluster_columns</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>cluster_column_slices</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>clustering_distance_columns</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>clustering_method_columns</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_dend_width</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>show_column_dend</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_dend_reorder</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_dend_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_order</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_km</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_km_repeats</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>column_split</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>width</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_width</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,

    <span class='co'>### global setting</span>
    <span class='kw'>heatmap_row_names_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_column_names_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_row_title_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_column_title_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_title_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_title_position</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_labels_gp</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_grid_height</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_grid_width</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>legend_border</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>heatmap_border</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>annotation_border</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>fastcluster</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>simple_anno_size</span> <span class='kw'>=</span> <span class='kw'>NULL</span>,
    <span class='kw'>show_parent_dend_line</span> <span class='kw'>=</span> <span class='kw'>NULL</span>)</pre>
    
    <h2 class="hasAnchor" id="arguments"><a class="anchor" href="#arguments"></a>Arguments</h2>
    <table class="ref-arguments">
    <colgroup><col class="name" /><col class="desc" /></colgroup>
    <tr>
      <th>object</th>
      <td><p>a <code><a href='HeatmapList-class.rd.html'>HeatmapList-class</a></code> object.</p></td>
    </tr>
    <tr>
      <th>newpage</th>
      <td><p>whether create a new page for the graphics. If you want to arrange multiple plots in one page, I suggest to use <code><a href='https://rdrr.io/r/grid/grid.grab.html'>grid.grabExpr</a></code>.</p></td>
    </tr>
    <tr>
      <th>row_title</th>
      <td><p>title on the row.</p></td>
    </tr>
    <tr>
      <th>row_title_side</th>
      <td><p>will the title be put on the left or right of the heatmap.</p></td>
    </tr>
    <tr>
      <th>row_title_gp</th>
      <td><p>graphic parameters for drawing text.</p></td>
    </tr>
    <tr>
      <th>column_title</th>
      <td><p>title on the column.</p></td>
    </tr>
    <tr>
      <th>column_title_side</th>
      <td><p>will the title be put on the top or bottom of the heatmap.</p></td>
    </tr>
    <tr>
      <th>column_title_gp</th>
      <td><p>graphic parameters for drawing text.</p></td>
    </tr>
    <tr>
      <th>heatmap_legend_side</th>
      <td><p>side to put heatmap legend</p></td>
    </tr>
    <tr>
      <th>merge_legends</th>
      <td><p>merge heatmap legends and annotation legends to put into one column.</p></td>
    </tr>
    <tr>
      <th>show_heatmap_legend</th>
      <td><p>whether show all heatmap legends</p></td>
    </tr>
    <tr>
      <th>heatmap_legend_list</th>
      <td><p>use-defined legends which are put after the heatmap legends</p></td>
    </tr>
    <tr>
      <th>annotation_legend_side</th>
      <td><p>side of the annotation legends</p></td>
    </tr>
    <tr>
      <th>show_annotation_legend</th>
      <td><p>whether show annotation legends</p></td>
    </tr>
    <tr>
      <th>annotation_legend_list</th>
      <td><p>user-defined legends which are put after the annotation legends</p></td>
    </tr>
    <tr>
      <th>gap</th>
      <td><p>gap between heatmaps/annotations</p></td>
    </tr>
    <tr>
      <th>ht_gap</th>
      <td><p>same as <code>gap</code>.</p></td>
    </tr>
    <tr>
      <th>main_heatmap</th>
      <td><p>index of main heatmap. The value can be a numeric index or the heatmap name</p></td>
    </tr>
    <tr>
      <th>padding</th>
      <td><p>padding of the whole plot. The value is a unit vector of length 4, which corresponds to bottom, left, top and right.</p></td>
    </tr>
    <tr>
      <th>adjust_annotation_extension</th>
      <td><p>whether take annotation name into account when calculating positions of graphic elements.</p></td>
    </tr>
    <tr>
      <th>auto_adjust</th>
      <td><p>whether apply automatic adjustment? The auto-adjustment includes turning off dendrograms, titles and row/columns for non-main heatmaps.</p></td>
    </tr>
    <tr>
      <th>row_dend_side</th>
      <td><p>side of the dendrogram from the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_sub_title_side</th>
      <td><p>side of the row title from the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_dend_side</th>
      <td><p>side of the dendrogram from the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_sub_title_side</th>
      <td><p>side of the column title from the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_gap</th>
      <td><p>this modifies <code>row_gap</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>cluster_rows</th>
      <td><p>this modifies <code>cluster_rows</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>cluster_row_slices</th>
      <td><p>this modifies <code>cluster_row_slices</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>clustering_distance_rows</th>
      <td><p>this modifies <code>clustering_distance_rows</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>clustering_method_rows</th>
      <td><p>this modifies <code>clustering_method_rows</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_dend_width</th>
      <td><p>this modifies <code>row_dend_width</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>show_row_dend</th>
      <td><p>this modifies <code>show_row_dend</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_dend_reorder</th>
      <td><p>this modifies <code>row_dend_reorder</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_dend_gp</th>
      <td><p>this modifies <code>row_dend_gp</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_order</th>
      <td><p>this modifies <code>row_order</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>km</th>
      <td><p>= this modifies <code>km</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>split</th>
      <td><p>this modifies <code>split</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_km</th>
      <td><p>this modifies <code>row_km</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_km_repeats</th>
      <td><p>this modifies <code>row_km_repeats</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>row_split</th>
      <td><p>this modifies <code>row_split</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>height</th>
      <td><p>this modifies <code>height</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>heatmap_height</th>
      <td><p>this modifies <code>heatmap_height</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_gap</th>
      <td><p>this modifies <code>column_gap</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>cluster_columns</th>
      <td><p>this modifies <code>cluster_columns</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>cluster_column_slices</th>
      <td><p>this modifies <code>cluster_column_slices</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>clustering_distance_columns</th>
      <td><p>this modifies <code>clustering_distance_columns</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>clustering_method_columns</th>
      <td><p>this modifies <code>clustering_method_columns</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_dend_width</th>
      <td><p>this modifies <code>column_dend_width</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>show_column_dend</th>
      <td><p>this modifies <code>show_column_dend</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_dend_reorder</th>
      <td><p>this modifies <code>column_dend_reorder</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_dend_gp</th>
      <td><p>this modifies <code>column_dend_gp</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_order</th>
      <td><p>this modifies <code>column_order</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_km</th>
      <td><p>this modifies <code>column_km</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_km_repeats</th>
      <td><p>this modifies <code>column_km_repeats</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>column_split</th>
      <td><p>this modifies <code>column_split</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>width</th>
      <td><p>this modifies <code>width</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>heatmap_width</th>
      <td><p>this modifies <code>heatmap_width</code> of the main heatmap</p></td>
    </tr>
    <tr>
      <th>heatmap_row_names_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>heatmap_column_names_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>heatmap_row_title_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>heatmap_column_title_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_title_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_title_position</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_labels_gp</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_grid_height</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_grid_width</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>legend_border</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>heatmap_border</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>annotation_border</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>fastcluster</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>simple_anno_size</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    <tr>
      <th>show_parent_dend_line</th>
      <td><p>this set the value in <code><a href='ht_opt.rd.html'>ht_opt</a></code> and reset back after the plot is done</p></td>
    </tr>
    </table>
    
    <h2 class="hasAnchor" id="details"><a class="anchor" href="#details"></a>Details</h2>

    <p>The function first calls <code><a href='make_layout-HeatmapList-method.rd.html'>make_layout,HeatmapList-method</a></code> to calculate
the layout of the heatmap list and the layout of every single heatmap,
then makes the plot by re-calling the graphic functions which are already recorded
in the layout.</p>
    
    <h2 class="hasAnchor" id="see-also"><a class="anchor" href="#see-also"></a>See also</h2>

    <div class='dont-index'><p><a href='https://jokergoo.github.io/ComplexHeatmap-reference/book/a-list-of-heatmaps.html'>https://jokergoo.github.io/ComplexHeatmap-reference/book/a-list-of-heatmaps.html</a></p></div>
    
    <h2 class="hasAnchor" id="value"><a class="anchor" href="#value"></a>Value</h2>

    <p>This function returns a <code><a href='HeatmapList-class.rd.html'>HeatmapList-class</a></code> object for which the layout has been created.</p>
    

    <h2 class="hasAnchor" id="examples"><a class="anchor" href="#examples"></a>Examples</h2>
    <pre class="examples"><div class='input'><span class='co'># There is no example</span>
<span class='kw'>NULL</span></div><div class='output co'>#&gt; NULL</div><div class='input'>
</div></pre>
  </div>
  <div class="col-md-3 hidden-xs hidden-sm" id="sidebar">
    <h2>Contents</h2>
    <ul class="nav nav-pills nav-stacked">
      <li><a href="#arguments">Arguments</a></li>
      
      <li><a href="#details">Details</a></li>

      <li><a href="#see-also">See also</a></li>

      <li><a href="#value">Value</a></li>
      
      <li><a href="#examples">Examples</a></li>
    </ul>

    <h2>Author</h2>
    <p>Zuguang Gu &lt;z.gu@dkfz.de&gt;</p>
  </div>
</div>


      <footer>
      <div class="copyright">
  <p>Developed by Zuguang Gu.</p>
</div>

<div class="pkgdown">
  <p>Site built with <a href="https://pkgdown.r-lib.org/">pkgdown</a> 1.4.1.</p>
</div>

      </footer>
   </div>

  


  </body>
</html>


