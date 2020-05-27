<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "product_product".
 *
 * @property int $id TRIAL
 * @property int|null $message_main_attachment_id TRIAL
 * @property string|null $default_code TRIAL
 * @property int|null $active TRIAL
 * @property int $product_tmpl_id TRIAL
 * @property string|null $barcode TRIAL
 * @property string|null $combination_indices TRIAL
 * @property float|null $volume TRIAL
 * @property float|null $weight TRIAL
 * @property int|null $can_image_variant_1024_be_zoomed TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial375 TRIAL
 *
 * @property ResUsers $createU
 * @property IrAttachment $messageMainAttachment
 * @property ResUsers $writeU
 * @property SaleOrderLine[] $saleOrderLines
 */
class ProductProduct extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'product_product';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['message_main_attachment_id', 'active', 'product_tmpl_id', 'can_image_variant_1024_be_zoomed', 'create_uid', 'write_uid'], 'integer'],
            [['default_code', 'barcode', 'combination_indices'], 'string'],
            [['product_tmpl_id'], 'required'],
            [['volume', 'weight'], 'number'],
            [['create_date', 'write_date'], 'safe'],
            [['trial375'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'default_code' => 'Default Code',
            'active' => 'Active',
            'product_tmpl_id' => 'Product Tmpl ID',
            'barcode' => 'Barcode',
            'combination_indices' => 'Combination Indices',
            'volume' => 'Volume',
            'weight' => 'Weight',
            'can_image_variant_1024_be_zoomed' => 'Can Image Variant 1024 Be Zoomed',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial375' => 'Trial375',
        ];
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[MessageMainAttachment]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['product_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ProductProductQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ProductProductQuery(get_called_class());
    }
}
